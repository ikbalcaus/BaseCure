using BaseCureAPI.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.Lijek.GetForUstanova
{
    [Route("/lijekovi/apoteka")]
    [ApiController]
    public class LijekoviController : ControllerBase
    {
        private readonly BasecureContext _context;

        public LijekoviController(BasecureContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LijekoviGetByUstanovaRes>>> GetLijekoviForUstanova([FromQuery] int ustanovaId)
        {
            var lijekovi = await _context.Lijekovis
                .Where(l => l.UstanovaId == ustanovaId)
                .Select(l => new LijekoviGetByUstanovaRes
                {
                    LijekId = l.LijekId,
                    NazivLijeka = l.NazivLijeka,
                    ZahtijevaRecept = l.ZahtijevaRecept,
                    OpisLijeka = l.OpisLijeka,
                    Kolicina = l.Kolicina,
                    CijenaLijeka = l.CijenaLijeka
                })
                .ToListAsync();

            return lijekovi;
        }
    }
}
