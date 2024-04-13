using BaseCureAPI.DB;
using BaseCureAPI.DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Endpoints.Lijek.GetAll
{
    [Route("lijekovi")]
    [ApiController]
    public class LijekoviGetAllEndpoints : ControllerBase
    {
        private readonly BasecureContext _context;

        public LijekoviGetAllEndpoints(BasecureContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetLijekovi()
        {
            var lijekovi = _context.Lijekovis.OrderByDescending(x => x.LijekId).
                Select(x => new LijekoviGetAllRes()
                {
                    LijekId = x.LijekId,
                    NazivLijeka = x.NazivLijeka,
                    CijenaLijeka = x.CijenaLijeka,
                    Kolicina = x.Kolicina,
                    ZahtijevaRecept = x.ZahtijevaRecept,
                    OpisLijeka = x.OpisLijeka
                }).ToList();
            return Ok(lijekovi);
        }
    }
}
