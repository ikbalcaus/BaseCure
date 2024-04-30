using BaseCureAPI.DB;
using BaseCureAPI.DB.Models;
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

        [HttpGet("apoteka/{ustanovaId}/{status}")]
        public ActionResult<List<NarudzbaGetApotekaDetaljiRes>> GetNarudzbe([FromRoute] int ustanovaId, string status)
        {
            var narudzbe = _context.Narudzbes
                .Include(x => x.Korisnik)
                .Include(x => x.Lijek)
                .Where(x => x.Lijek.UstanovaId == ustanovaId && x.Status == status && (x.Status == "aktivno" || x.Status == "isporuceno"))
                .Select(x => new NarudzbaGetKorisnikRes
                {
                    NarudzbaId = x.NarudzbaId,
                    KorisnikId = x.KorisnikId,
                    LijekId = x.LijekId,
                    NazivLijeka = x.Lijek.NazivLijeka,
                    OpisLijeka = x.Lijek.OpisLijeka,
                    CijenaLijeka = x.Lijek.CijenaLijeka,
                    Status = x.Status
                })
                .ToList();
            return Ok(narudzbe);
        }
    }
}
