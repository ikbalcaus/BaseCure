using BaseCureAPI.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.Korisnik.GetAll
{
    [Route("korisnici")]
    [ApiController]
    public class KorisniciController : ControllerBase
    {
        private readonly BasecureContext _context;

        public KorisniciController(BasecureContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var korisnici = _context.Korisnicis.OrderByDescending(x => x.KorisnikId)
                .Select(x => new KorisniciGetAllRes()
                {
                    KorisnikId = x.KorisnikId,
                    HashLozinke = x.HashLozinke,
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    Adresa = x.Adresa,
                    DatumRodjenja = x.DatumRodjenja,
                    MailAdresa = x.MailAdresa,
                    Code2fa = x.Code2fa
                }).ToList();

            return Ok(korisnici);
        }
    }
}