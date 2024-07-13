using BaseCureAPI.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.Lijek.GetForUstanova
{
    [Route("/lijekovi")]
    [ApiController]
    public class LijekoviController : ControllerBase
    {
        private readonly BasecureContext _context;

        public LijekoviController(BasecureContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetLijekoviForUstanova([FromQuery] int ustanovaId)
        {
            var lijekovi = _context.Lijekovis
                .Where(x => x.UstanovaId == ustanovaId)
                .Select(x => new LijekoviGetByUstanovaRes
                {
                    LijekId = x.LijekId,
                    NazivLijeka = x.NazivLijeka,
                    ZahtijevaRecept = x.ZahtijevaRecept,
                    OpisLijeka = x.OpisLijeka,
                    Kolicina = x.Kolicina,
                    CijenaLijeka = x.CijenaLijeka
                })
                .ToList();

            return Ok(lijekovi);
        }
    }
}
