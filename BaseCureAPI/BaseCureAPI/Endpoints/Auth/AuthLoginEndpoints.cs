using BaseCureAPI.DB;
using BaseCureAPI.DB.Models;
using BaseCureAPI.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;
using SendGrid;
using BCrypt.Net;
using Microsoft.Identity.Client;
using BaseCureAPI.Services;
using static AuthService;

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

            return Ok(new { token });
        }

        [HttpPost("verify-code")]
        public IActionResult VerifyCode([FromBody] VerificationRequest request)
        {
            string userEnteredCode = request.VerificationCode;
            string storedCode = "0000"; // Dummy code for now, should fetch from DB

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

            return Ok(new { newUser.KorisnikId });
        }

        [HttpPost("changePassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ChangePasswordReq req)
        {
            if (string.IsNullOrEmpty(req.StaraSifra) || string.IsNullOrEmpty(req.NovaSifra) || string.IsNullOrEmpty(req.PotvrdiNovuSifru))
            {
                return BadRequest(new { message = "Niste unijeli sve podatke" });
            }

            if (req.NovaSifra != req.PotvrdiNovuSifru)
            {
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

            return NoContent();
        }

        [HttpPost("generateHash")]
        public IActionResult GenerateHash([FromBody] GenerateHashReq req)
        {
            return Ok(BCrypt.Net.BCrypt.HashPassword(req.String));
        }

        public class GenerateHashReq
        {
            public string String { get; set; }
        }

        public class ChangePasswordReq
        {
            public int KorisnikId { get; set; }
            public string StaraSifra {  get; set; }
            public string NovaSifra { get; set; }
            public string PotvrdiNovuSifru { get; set; }
        }


        public class KorisniciDto
        {
            public string IpAdresa { get; set; }
            public string Vrijednost { get; set; }
            public Guid Korisnik { get; set; }
        }
    }
}
