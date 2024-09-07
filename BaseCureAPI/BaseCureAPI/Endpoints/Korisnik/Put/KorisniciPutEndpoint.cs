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

            // Update basic user information
            korisnik.Ime = korisnikReq.Ime;
            korisnik.Prezime = korisnikReq.Prezime;
            korisnik.Grad = grad;
            korisnik.Adresa = korisnikReq.Adresa;
            korisnik.MailAdresa = korisnikReq.MailAdresa;
            korisnik.BrojTelefona = korisnikReq.BrojTelefona;

            if (!string.IsNullOrWhiteSpace(korisnikReq.OldPassword) &&
                !string.IsNullOrWhiteSpace(korisnikReq.NewPassword) &&
                !string.IsNullOrWhiteSpace(korisnikReq.RepeatNewPassword))
            {
                if (!BCrypt.Net.BCrypt.Verify(korisnikReq.OldPassword, korisnik.HashLozinke))
                {
                    return BadRequest(new { message = "Stara lozinka nije tačna" });
                }

                if (korisnikReq.NewPassword != korisnikReq.RepeatNewPassword)
                {
                    return BadRequest(new { message = "Nova lozinka i ponovljena lozinka se ne podudaraju" });
                }

                korisnik.HashLozinke = BCrypt.Net.BCrypt.HashPassword(korisnikReq.NewPassword);
            }

            _context.SaveChanges();

            return NoContent();
        }

    }
}