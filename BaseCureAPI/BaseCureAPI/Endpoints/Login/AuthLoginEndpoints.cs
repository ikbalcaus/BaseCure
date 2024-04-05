using BaseCureAPI.DB;
using BaseCureAPI.DB.Models;
using BaseCureAPI.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


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

        [HttpPost("login")]
        public ActionResult Obradi([FromBody] AuthLoginReq request)
        {
            if (request == null)
            {
                return BadRequest("Došlo je do greške na serveru");
            }

            var logiraniKorisnik = _context.Korisnicis
                .FirstOrDefault(k =>
                    k.KorisnickoIme == request.KorisnickoIme && k.HashLozinke == request.Lozinka);

            if (logiraniKorisnik == null)
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
    }
}
