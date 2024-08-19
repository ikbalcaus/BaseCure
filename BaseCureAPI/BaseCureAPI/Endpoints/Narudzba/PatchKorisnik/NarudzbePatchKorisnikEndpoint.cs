using BaseCureAPI.DB;
using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Endpoints.Narudzba.PatchKorisnik
{
    [Route("narudzbe")]
    [ApiController]
    public class NaruzbeController : ControllerBase
    {
        private readonly BasecureContext _context;

        public NaruzbeController(BasecureContext context)
        {
            _context = context;
        }

        [HttpPatch("korisnik/{korisnikId}")]
        public ActionResult UpdateNarudzba([FromRoute] int korisnikId, [FromBody] NarudzbePatchKorisnikReq req)
        {
            var narudzbe = _context.Narudzbes.Where(x => x.KorisnikId == korisnikId && x.Status == "neaktivno");
            var grad = _context.Gradovis.SingleOrDefault(x => x.Naziv == req.Grad);

            if (grad == null)
            {
                return BadRequest("Grad ne postoji");
            }

            if (req.ImePrezime == "" || req.BrojTelefona == "" || req.Adresa == "" || req.MailAdresa == "")
            {
                return BadRequest("Niste unijeli ispravne podatke");
            }

            foreach (var narudzba in narudzbe)
            {
                narudzba.ImePrezime = req.ImePrezime;
                narudzba.BrojTelefona = req.BrojTelefona;
                narudzba.Grad = grad;
                narudzba.Adresa = req.Adresa;
                narudzba.Mailadresa = req.MailAdresa;
                narudzba.Status = "aktivno";
                narudzba.RedniBroj = _context.Narudzbes.Max(x => x.RedniBroj) + 1;
            }
            _context.SaveChanges();
            return NoContent();
        }
    }
}
