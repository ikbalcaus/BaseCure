using BaseCureAPI.DB;
using BaseCureAPI.DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Endpoints.Lijek.GetByParams
{
    [Route("lijekovi")]
    [ApiController]
    public class LijekoviController : ControllerBase
    {
        private readonly BasecureContext _context;

        public LijekoviController(BasecureContext context)
        {
            _context = context;
        }

        [HttpGet("search")]
        public ActionResult<IEnumerable<Lijekovi>> GetLijekoviByParams(
                int UstanovaId,
                string? NazivLijeka,
                string? OpisLijeka)
        {
            var query = _context.Lijekovis.AsQueryable();
            
            query = query.Where(x => x.UstanovaId == UstanovaId);


            if (!string.IsNullOrEmpty(NazivLijeka))
            {
                query = query.Where(x => x.NazivLijeka == NazivLijeka);
            }

            if (!string.IsNullOrEmpty(OpisLijeka))
            {
                query = query.Where(x => x.OpisLijeka == OpisLijeka);
            }

            return query.ToList();
        }
    }
}
