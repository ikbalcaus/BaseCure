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
            var korisnik = _context.Korisnicis.OrderByDescending(x => x.KorisnikId)
                .Select(x => new KorisniciGetAllRes()
                {
                    KorisnikId = x.KorisnikId,
                    KorisnickoIme = x.KorisnickoIme,
                    HashLozinke = x.HashLozinke,
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    //Adresa = x.Adresa,
                    //DatumRodjenja = (DateTime)x.DatumRodjenja,
                    //MailAdresa = x.MailAdresa,
                    //Uloga = x.Uloga,
                }).ToList();

            return Ok(new KorisniciGetAllResList
            {
                Korisnici = korisnik
            });
        }
    }
}