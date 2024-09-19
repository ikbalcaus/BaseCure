using BaseCureAPI.DB;
using BaseCureAPI.DB.Models;
using BaseCureAPI.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;
using SendGrid;
using BCrypt.Net;
<<<<<<< HEAD
using Microsoft.Identity.Client;
using BaseCureAPI.Services;
using static AuthService;
=======
>>>>>>> parent of cc64a5f (Updated password changing)

namespace BaseCureAPI.Endpoints.Auth
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly BasecureContext _context;
        private readonly IAuthService _authService;

        public AuthController(BasecureContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthLoginReq request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request.");
            }

            var token = await _authService.AuthenticateUser(request.MailAdresa, request.Lozinka);
            if (token == null)
                return Unauthorized();

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var noviToken = new AuthToken()
                    {
                        IpAdresa = Request.HttpContext.Connection.RemoteIpAddress?.ToString(),
                        Vrijednost = token,
                        KorisnikId = _context.Korisnicis.SingleOrDefault(k => k.MailAdresa == request.MailAdresa).KorisnikId,
                        Korisnik = await _context.Korisnicis.SingleOrDefaultAsync(k => k.MailAdresa == request.MailAdresa),
                        VrijemeEvidentiranja = DateTime.Now,
                        Code2f = Guid.NewGuid().ToString(),
                    };

                    noviToken.AuthTokenId = _context.AuthTokens.Any() ? _context.AuthTokens.Max(t => t.AuthTokenId) + 1 : 1;

                    _context.AuthTokens.Add(noviToken);
                    await _context.SaveChangesAsync();

                    transaction.Commit();

                    var response = new AuthLoginRes()
                    {
                        Vrijednost = noviToken.Vrijednost,
                        Code2f = noviToken.Code2f,
                        KorisnikId = noviToken.KorisnikId,
                        Korisnik = noviToken.Korisnik,
                        IpAdresa = noviToken.IpAdresa,
                        VrijemeEvidentiranja = noviToken.VrijemeEvidentiranja,
                    };

                    return Ok( response );
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return StatusCode(500, $"Došlo je do greške: {ex.Message}");
                }
            }
        }

        [HttpPost("verify-code")]
        public IActionResult VerifyCode([FromBody] VerificationRequest request)
        {
            string userEnteredCode = request.VerificationCode;
            string storedCode = "0000";

            if (userEnteredCode == storedCode)
            {
                return Ok("Verification successful");
            }
            return BadRequest("Invalid verification code");
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] AuthRegisterReq request)
        {
            if (request == null)
                return BadRequest("Došlo je do greške na serveru");

            // Hash password
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Lozinka);

            // Generate new user ID
            int newKorisnikId = _context.Korisnicis.Any() ? _context.Korisnicis.Max(k => k.KorisnikId) + 1 : 1;

            var newUser = new Korisnici
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

<<<<<<< HEAD
            return Ok(new { newUser.KorisnikId });
        }

        [HttpPost("changePassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ChangePasswordReq req)
=======
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
>>>>>>> parent of cc64a5f (Updated password changing)
        {
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.NewPassword))
            {
<<<<<<< HEAD
                return BadRequest(new { message = "Niste unijeli sve podatke" });
=======
                return BadRequest("Email and new password are required.");
>>>>>>> parent of cc64a5f (Updated password changing)
            }

            var user = await _context.Korisnicis.FirstOrDefaultAsync(x => x.MailAdresa == request.Email);

            if (user == null)
            {
<<<<<<< HEAD
                return BadRequest(new { message = "Šifre se ne podudaraju" });
            }

            var user = await _context.Korisnicis.FindAsync(req.KorisnikId);

            if (user == null || !BCrypt.Net.BCrypt.Verify(req.StaraSifra, user.HashLozinke))
            {
                return BadRequest(new { message = "Niste unijeli ispravnu šifru" });
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(req.NovaSifra);
            user.HashLozinke = hashedPassword;
            _context.Korisnicis.Update(user);
            await _context.SaveChangesAsync();
=======
                return NotFound("Korisnik sa ovom email adresom nije pronađen.");
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);

            user.HashLozinke = hashedPassword;
            _context.Korisnicis.Update(user);
>>>>>>> parent of cc64a5f (Updated password changing)

            await _context.SaveChangesAsync();

            return Ok("Šifra uspešno resetovana.");
        }

<<<<<<< HEAD
        [HttpPost("generateHash")]
        public IActionResult GenerateHash([FromBody] GenerateHashReq req)
=======
        public class ResetPasswordRequest
>>>>>>> parent of cc64a5f (Updated password changing)
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
