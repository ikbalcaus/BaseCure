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
            var korisnik = _context.Korisnicis.Find(id);
            if (korisnik == null)
            {
                return NotFound();
            }
            korisnik.HashLozinke = korisnikReq.HashLozinke;
            korisnik.Ime = korisnikReq.Ime;
            korisnik.Prezime = korisnikReq.Prezime;
            korisnik.Adresa = korisnikReq.Adresa;
            korisnik.DatumRodjenja = korisnikReq.DatumRodjenja;
            korisnik.MailAdresa = korisnikReq.MailAdresa;
            korisnik.Code2fa = korisnikReq.Code2fa;
            korisnik.BrojTelefona = korisnikReq.BrojTelefona;

            _context.SaveChanges();

            return NoContent();
        }
    }
}