using BaseCureAPI.DB;
using BaseCureAPI.DB.Models;
using BaseCureAPI.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static BaseCureAPI.Services.MyAuthService;


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

        // POST auth/login
        [HttpPost("login")]
        public  ActionResult<AuthToken> Obradi([FromBody] AuthLoginReq request)
        {
            if (request == null)
            {
                return BadRequest("Request data is null");
            }

            //1- provjera logina
            var logiraniKorisnik =  _context.Korisnicis
                .FirstOrDefault(k =>
                    k.KorisnickoIme == request.KorisnickoIme && k.HashLozinke == request.Lozinka);

            if (logiraniKorisnik == null)
            {
                //pogresan username i password
                return Unauthorized("Incorrect username or password");
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
