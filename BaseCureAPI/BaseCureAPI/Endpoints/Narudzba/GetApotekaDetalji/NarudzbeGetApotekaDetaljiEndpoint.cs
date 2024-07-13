using BaseCureAPI.DB;
using BaseCureAPI.Endpoints.Narudzba.GetKorisnik;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.Narudzba.GetApotekaDetalji
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

        [HttpGet("apoteka/{ustanovaId}/detalji")]
        public ActionResult GetNarudzbe([FromRoute] int ustanovaId, [FromQuery] string status, [FromQuery] int redniBroj)
        {
            var narudzbe = _context.Narudzbes
                .Include(x => x.Grad)
                .Include(x => x.Korisnik)
                .Include(x => x.Lijek)
                .ThenInclude(x => x.Ustanova)
                .Where(x => x.Lijek.UstanovaId == ustanovaId && x.Status == status && x.RedniBroj == redniBroj && (x.Status == "aktivno" || x.Status == "isporuceno"))
                .Select(x => new NarudzbeGetApotekaDetaljiRes
                {
                    NarudzbaId = x.NarudzbaId,
                    KorisnikId = x.KorisnikId,
                    ImePrezime = x.ImePrezime,
                    TelefonskiBroj = x.TelefonskiBroj,
                    Grad = x.Grad.Naziv,
                    Adresa = x.Adresa,
                    MailAdresa = x.Mailadresa,
                    LijekId = x.LijekId,
                    NazivLijeka = x.Lijek.NazivLijeka,
                    OpisLijeka = x.Lijek.OpisLijeka,
                    CijenaLijeka = x.Lijek.CijenaLijeka,
                    CijenaDostave = x.Lijek.Ustanova.CijenaDostave,
                    Status = x.Status
                })
                .ToList();
            return Ok(narudzbe);
        }
    }
}
