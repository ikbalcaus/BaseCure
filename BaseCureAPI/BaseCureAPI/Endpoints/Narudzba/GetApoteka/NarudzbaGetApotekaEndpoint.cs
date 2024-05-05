using BaseCureAPI.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.Narudzba.GetApoteka
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

        [HttpGet("apoteka/{ustanovaId}")]
        public ActionResult<List<NarudzbaGetApotekaRes>> GetNarudzbe([FromRoute] int ustanovaId)
        {
            var narudzbe = _context.Narudzbes
                .Where(x => x.Status == "aktivno" || x.Status == "isporuceno")
                .GroupBy(x => new { x.KorisnikId, x.Korisnik.Ime, x.Korisnik.Prezime, x.Status })
                .Select(group => new NarudzbaGetApotekaRes
                {
                    KorisnikId = group.Key.KorisnikId,
                    ImePrezime = group.Key.Ime + " " + group.Key.Prezime,
                    Status = group.Key.Status,
                    BrojLijekova = group.Select(x => x.LijekId).Count()
                }).ToList();
            return Ok(narudzbe);
        }
    }
}
