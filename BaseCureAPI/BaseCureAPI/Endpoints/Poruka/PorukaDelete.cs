using BaseCureAPI.DB;
using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Endpoints.Poruka.Delete
{
    [Route("poruke")]
    [ApiController]
    public class PorukeController : ControllerBase
    {
        private readonly BasecureContext _context;

        public PorukeController(BasecureContext context)
        {
            _context = context;
        }

        [HttpDelete("{id}")]
        public ActionResult Get([FromRoute] int id, [FromQuery] int korisnikId1, [FromQuery] int korisnikId2)
        {
            var poruka = _context.Porukes.Find(id);
            
            if (poruka == null)
            {
                return NotFound();
            }

            if (poruka.PosiljaocId != korisnikId1 || poruka.PrimaocId != korisnikId2)
            {
                return Forbid();
            }

            _context.Porukes.Remove(poruka);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
