using BaseCureAPI.DB;
using BaseCureAPI.DB.Models;
using BaseCureAPI.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;
using SendGrid;



namespace BaseCureAPI.Endpoints.Login
{
    [Route("auth")]
    [ApiController]
    public class AuthLoginEndpoints : ControllerBase
    {
        private readonly BasecureContext _context;

        public AuthLoginEndpoints(BasecureContext context)
        {
            _context = context;
        }

        [HttpPost("/verify-code")]
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
        public async Task<ActionResult<AuthToken>> RegisterUser([FromBody] AuthRegisterReq request)
        {
            if (request == null)
            {
                return BadRequest("Došlo je do greške na serveru");
            }

            // Check if the username already exists
            if (_context.Korisnicis.Any(k => k.KorisnickoIme == request.KorisnickoIme))
            {
                return BadRequest("Korisničko ime već postoji");
            }

            // Create a new user
            var newUser = new Korisnici()
            {
                KorisnickoIme = request.KorisnickoIme,
                HashLozinke = request.Lozinka,
                MailAdresa = request.MailAdresa,
                // Add other user properties as needed
            };

            // Add the user to the database
            _context.Add(newUser);
            _context.SaveChanges();

            // Generate a random 2FA code
            string twoFactorCode = TokenGen.Generate(6);

            // Associate the 2FA code with the user
            newUser.Code2fa = twoFactorCode;
            _context.SaveChanges();

            // Send the 2FA code via email using SendGrid
            string sendGridApiKey = "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";

            var client = new SendGridClient(sendGridApiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("abdullah.salcinovic@gmail.com", "Abdullah Salcinovic"),
                Subject = "Your 2FA Code",
                PlainTextContent = $"Your verification code is: {twoFactorCode}",
                HtmlContent = $"<p>Your verification code is: {twoFactorCode}</p>"
            };

            msg.AddTo(new EmailAddress(newUser.MailAdresa));

            var response = await client.SendEmailAsync(msg);

            if (response.StatusCode != System.Net.HttpStatusCode.OK && response.StatusCode != System.Net.HttpStatusCode.Accepted)
            {
                // Handle the case when sending email fails
                return StatusCode((int)response.StatusCode, "Failed to send email");
            }

            // Return the user's information without the 2FA code
            return Ok(new
            {
                newUser.KorisnikId,
                newUser.KorisnickoIme
                // Exclude TwoFactorCode here since it's sent via email
            });
        }

        // POST auth/login
        [HttpPost("login")]
        public ActionResult<AuthToken> Obradi([FromBody] AuthLoginReq request)
        {
            if (request == null)
            {
                return BadRequest("Došlo je do greške na serveru");
            }

            //1- provjera logina
            var logiraniKorisnik = _context.Korisnicis
                .FirstOrDefault(k =>
                    k.KorisnickoIme == request.KorisnickoIme && k.HashLozinke == request.Lozinka);

            if (logiraniKorisnik == null)
            {
                //pogresan username i password
                return Ok(null);
            }

            //2- generisati random string
            string randomString = TokenGen.Generate(10);

            //3- dodati novi zapis u tabelu AutentifikacijaToken za logiraniKorisnikId i randomString
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

            //4- vratiti token string
            return Ok(noviToken);
        }

        public class KorisniciDto
        {
            public string IpAdresa { get; set; }
            public string Vrijednost { get; set; }
            public Guid Korisnik { get; set; }
        }
    }
}
