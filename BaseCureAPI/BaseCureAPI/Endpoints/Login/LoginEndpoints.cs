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
    public class LoginEndpoints : ControllerBase
    {
        private readonly BaseCureContext _context;

        public LoginEndpoints(BaseCureContext context)
        {
            _context = context;
        }

        // POST auth/login
        [HttpPost("login")]
        public async Task<MyAuthInfo> Obradi([FromBody] AuthToken request, CancellationToken cancellationToken)
        {
            //1- provjera logina
            Korisnici? logiraniKorisnik = await _context.Korisnicis
                .FirstOrDefaultAsync(k =>
                    k.KorisnickoIme == request.Korisnik.KorisnickoIme && k.HashLozinke == request.Korisnik.HashLozinke, cancellationToken);

            if (logiraniKorisnik == null)
            {
                //pogresan username i password
                return new MyAuthInfo(null);
            }

            //2- generisati random string
            string randomString = TokenGen.Generate(10);

            //3- dodati novi zapis u tabelu AutentifikacijaToken za logiraniKorisnikId i randomString
            var noviToken = new AuthToken()
            {
                IpAdresa = Request.HttpContext.Connection.RemoteIpAddress?.ToString(),
                Vrijednost = randomString,
                Korisnik = logiraniKorisnik,
                VrijemeEvidentiranja = DateTime.Now,
                Code2F = Guid.NewGuid().ToString()
            };

            _context.Add(noviToken);
            await _context.SaveChangesAsync(cancellationToken);

            //4- vratiti token string
            return new MyAuthInfo(noviToken);
        }

    }
}
