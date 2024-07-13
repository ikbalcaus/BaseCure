using BaseCureAPI.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.Lijek.Put
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

        [HttpPut("{id}")]
        public IActionResult PutLijek(int id, [FromBody] LijekoviPutReq req)
        {
            var lijek = _context.Lijekovis.SingleOrDefault(x => x.LijekId == id);
            if (lijek == null)
            {
                return NotFound();
            }
            lijek.NazivLijeka = req.NazivLijeka;
            lijek.SlikaLijeka = req.SlikaLijeka;
            lijek.OpisLijeka = req.OpisLijeka;
            lijek.ZahtijevaRecept = req.ZahtijevaRecept;
            lijek.CijenaLijeka = req.CijenaLijeka;
            lijek.Kolicina = req.Kolicina;

            _context.SaveChanges();

            return NoContent();
        }
    }
}
