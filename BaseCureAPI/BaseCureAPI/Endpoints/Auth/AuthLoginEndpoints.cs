﻿using BaseCureAPI.DB;
using BaseCureAPI.DB.Models;
using BaseCureAPI.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;
using SendGrid;
using BCrypt.Net;

namespace BaseCureAPI.Endpoints.Auth
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly BasecureContext _context;

        public AuthController(BasecureContext context)
        {
            _context = context;
        }

        [HttpPost("verify-code")]
        public ActionResult VerifyCode([FromBody] VerificationRequest request)
        {
            // Retrieve the verification code sent by the user
            string userEnteredCode = request.VerificationCode;

            // Retrieve the stored verification code associated with the user (you'll need to fetch this from your database)
            string storedCode = "0000";

            // Compare the user-entered code with the stored code
            if (userEnteredCode == storedCode)
            {
                return Ok("Verification successful");
            }
            else
            {
                // Code is invalid
                return BadRequest("Invalid verification code");
            }
        }

        // POST auth/register
        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser([FromBody] AuthRegisterReq request)
        {
            if (request == null)
            {
                return BadRequest("Došlo je do greške na serveru");
            }

            // Hash the password
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Lozinka);

            // Generate a new unique KorisnikId
            int newKorisnikId = _context.Korisnicis.Any() ? _context.Korisnicis.Max(k => k.KorisnikId) + 1 : 1;

            var newUser = new Korisnici()
            {
                KorisnikId = newKorisnikId,
                HashLozinke = hashedPassword,
                MailAdresa = request.MailAdresa,
            };

            _context.Add(newUser);
            await _context.SaveChangesAsync();

            string twoFactorCode = TokenGen.Generate(6);

            newUser.Code2fa = twoFactorCode;
            await _context.SaveChangesAsync();

            return Ok(new
            {
                newUser.KorisnikId,
            });
        }

        // POST auth/login
        [HttpPost("login")]
        public ActionResult Obradi([FromBody] AuthLoginReq request)
        {
            if (request == null)
            {
                return BadRequest("Došlo je do greške na serveru");
            }

            // 1- Provjera logina
            var logiraniKorisnik = _context.Korisnicis
                .Include(x => x.Grad)
                .Include(x => x.Osoblje)
                .Include(x => x.Osoblje.Uloga)
                .Include(x => x.Osoblje.Ustanova)
                .FirstOrDefault(x => x.MailAdresa == request.MailAdresa);

            if (logiraniKorisnik == null || !BCrypt.Net.BCrypt.Verify(request.Lozinka, logiraniKorisnik.HashLozinke))
            {
                // Pogresan username i password
                return Unauthorized();
            }

            // 2- Generisati random string
            string randomString = TokenGen.Generate(10);

            // Use database transaction to ensure safe insertion without conflicts
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // 3- Dodati novi zapis u tabelu AuthToken za logiraniKorisnikId i randomString
                    var noviToken = new AuthToken()
                    {
                        IpAdresa = Request.HttpContext.Connection.RemoteIpAddress?.ToString(),
                        Vrijednost = randomString,
                        KorisnikId = logiraniKorisnik.KorisnikId,
                        Korisnik = logiraniKorisnik,
                        VrijemeEvidentiranja = DateTime.Now,
                        Code2f = Guid.NewGuid().ToString(),
                    };

                    // Fetch the max AuthTokenId inside the transaction
                    noviToken.AuthTokenId = _context.AuthTokens.Any()
                        ? _context.AuthTokens.Max(x => x.AuthTokenId) + 1
                        : 1;

                    _context.Add(noviToken);
                    _context.SaveChanges();

                    // Commit the transaction
                    transaction.Commit();

                    // Create a response token for returning to the user
                    var resToken = new AuthLoginRes()
                    {
                        IpAdresa = Request.HttpContext.Connection.RemoteIpAddress?.ToString(),
                        Vrijednost = randomString,
                        KorisnikId = logiraniKorisnik.KorisnikId,
                        Korisnik = logiraniKorisnik,
                        VrijemeEvidentiranja = DateTime.Now,
                        Code2f = noviToken.Code2f, // Same as the one in noviToken
                    };

                    // 4- Vratiti token string
                    return Ok(resToken);
                }
                catch (Exception ex)
                {
                    // Rollback the transaction if there's an error
                    transaction.Rollback();
                    return StatusCode(500, $"Došlo je do greške: {ex.Message}");
                }
            }
        }


        [HttpPost("admin-login")]
        public ActionResult AdminLogin([FromBody] AuthLoginReq request)
        {

            if (request == null)
            {
                return BadRequest("Došlo je do greške na serveru");
            }

            var logiraniKorisnik = _context.Korisnicis
                .Include(k => k.Osoblje)
                .Include(k => k.Osoblje.Uloga)
                .Include(k => k.Osoblje.Ustanova)
                .FirstOrDefault(k =>
                    k.MailAdresa == request.MailAdresa && k.Osoblje.Uloga.Naziv == "admin");

            if (logiraniKorisnik == null || !BCrypt.Net.BCrypt.Verify(request.Lozinka, logiraniKorisnik.HashLozinke))
            {
                return Ok(null);
            }

            string randomString = TokenGen.Generate(10);

            var noviToken = new AuthToken()
            {
                IpAdresa = Request.HttpContext.Connection.RemoteIpAddress?.ToString(),
                Vrijednost = randomString,
                KorisnikId = logiraniKorisnik.KorisnikId,
                Korisnik = logiraniKorisnik,
                VrijemeEvidentiranja = DateTime.Now,
                Code2f = Guid.NewGuid().ToString(),
            };

            noviToken.AuthTokenId =
                _context.AuthTokens.Any() ? _context.AuthTokens.Max(x => x.AuthTokenId) + 1 : 1;

            _context.Add(noviToken);
            _context.SaveChanges();

            return Ok(noviToken);
        }

        [HttpPost("reset-password")]
        public async Task<ActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.NewPassword))
            {
                return BadRequest("Email and new password are required.");
            }

            var user = await _context.Korisnicis.FirstOrDefaultAsync(x => x.MailAdresa == request.Email);

            if (user == null)
            {
                return NotFound("Korisnik sa ovom email adresom nije pronađen.");
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);

            user.HashLozinke = hashedPassword;
            _context.Korisnicis.Update(user);

            await _context.SaveChangesAsync();

            return Ok("Šifra uspešno resetovana.");
        }

        public class ResetPasswordRequest
        {
            public string Email { get; set; }
            public string NewPassword { get; set; }
        }


        public class KorisniciDto
        {
            public string IpAdresa { get; set; }
            public string Vrijednost { get; set; }
            public Guid Korisnik { get; set; }
        }
    }
}
