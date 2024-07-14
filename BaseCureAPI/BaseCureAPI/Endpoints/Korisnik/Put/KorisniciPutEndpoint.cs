using BaseCureAPI.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.Korisnik.Put
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

        [HttpPut("{id}")]
        public ActionResult UpdateKorisnik(int id, [FromBody] KorisniciPutReq korisnikReq)
        {
            var korisnik = _context.Korisnicis.SingleOrDefault(x => x.KorisnikId == id);
            if (korisnik == null)
            {
                return NotFound();
            }

            var grad = _context.Gradovis.SingleOrDefault(x => x.Naziv == korisnikReq.Grad);

            if (grad == null)
            {
                return BadRequest(new { message = "Grad ne postoji" });
            }

            korisnik.Ime = korisnikReq.Ime;
            korisnik.Prezime = korisnikReq.Prezime;
            korisnik.Grad = grad;
            korisnik.Adresa = korisnikReq.Adresa;
            korisnik.MailAdresa = korisnikReq.MailAdresa;
            korisnik.BrojTelefona = korisnikReq.BrojTelefona;

            _context.SaveChanges();

            return NoContent();
        }
    }
}