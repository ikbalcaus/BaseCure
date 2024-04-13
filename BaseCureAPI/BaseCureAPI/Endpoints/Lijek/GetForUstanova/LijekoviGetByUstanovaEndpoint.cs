using BaseCureAPI.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.Lijek.GetForUstanova
{
    [Route("ustanove/{ustanovaId}/lijekovi")]
    [ApiController]
    public class LijekoviGetByUstanovaEndpoint : ControllerBase
    {
        private readonly BasecureContext _context;

        public LijekoviGetByUstanovaEndpoint(BasecureContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LijekoviGetByUstanovaRes>>> GetLijekoviForUstanova(int ustanovaId)
        {
            var lijekovi = await _context.Lijekovis
                .Where(l => l.UstanovaId == ustanovaId)
                .Select(l => new LijekoviGetByUstanovaRes
                {
                    LijekId = l.LijekId,
                    NazivLijeka = l.NazivLijeka,
                    ZahtijevaRecept = l.ZahtijevaRecept,
                    OpisLijeka = l.OpisLijeka
                })
                .ToListAsync();

            return lijekovi;
        }
    }
}
