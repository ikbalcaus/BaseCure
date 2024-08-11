using BaseCureAPI.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BaseCureAPI.Endpoints.Korisnik.PatchKonekcijskiId
{
    [Route("korisnici")]
    [ApiController]
    public class KorisniciController : ControllerBase
    {
        private readonly BasecureContext _context;

        public KorisniciController(BasecureContext context)
        {
            _context = context;
        }

        [HttpPatch("{id}")]
        public ActionResult UpdateKonekcijskiId([FromRoute] int id, [FromBody] KorisniciPatchKonekcijskiIdReq req)
        {
            var korisnik = _context.Korisnicis.Find(id);

            if (korisnik == null)
            {
                return NotFound();
            }

            korisnik.KonekcijskiId = req.KonekcijskiId;
            _context.SaveChanges();

            return NoContent();
        }
    }
}
