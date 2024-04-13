using BaseCureAPI.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.Korisnik.Put
{
    [Route("korisnici")]
    [ApiController]
    public class KorisniciPutEndpoint : ControllerBase
    {
        private readonly BasecureContext _context;

        public KorisniciPutEndpoint(BasecureContext context)
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
            korisnik.KorisnickoIme = korisnikReq.KorisnickoIme;
            korisnik.HashLozinke = korisnikReq.HashLozinke;
            korisnik.Ime = korisnikReq.Ime;
            korisnik.Prezime = korisnikReq.Prezime;
            // Update other properties as needed

            _context.SaveChanges();

            return NoContent();
        }
    }
}