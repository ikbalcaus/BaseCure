using BaseCureAPI.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.Korisnik.GetById
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

        [HttpGet("{id}")]
        public ActionResult GetKorisnik([FromRoute] int id)
        {
            var korisnikEntity = _context.Korisnicis
                .Include(x => x.Grad)
                .Include(x => x.Osoblje)
                    .ThenInclude(x => x.Uloga)
                .FirstOrDefault(x => x.KorisnikId == id);

            if (korisnikEntity == null)
            {
                return NotFound();
            }

            var korisnik = new KorisniciGetByIdRes
            {
                Ime = korisnikEntity.Ime,
                Prezime = korisnikEntity.Prezime,
                BrojTelefona = korisnikEntity.BrojTelefona,
                Adresa = korisnikEntity.Adresa,
                MailAdresa = korisnikEntity.MailAdresa,
                Grad = korisnikEntity.Grad?.Naziv,
                Uloga = korisnikEntity.Osoblje?.Uloga?.Naziv
            };

            if (korisnik == null)
            {
                return NotFound();
            }

            return Ok(korisnik);
        }
    }
}