using BaseCureAPI.DB;
using BaseCureAPI.DB.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Endpoints.Poruka.PatchAllMessagesOfUser
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

        [HttpPatch]
        public ActionResult Get([FromQuery] int korisnikId1, [FromQuery] int korisnikId2)
        {
            var poruke = _context.Porukes
                .Where(x => x.PosiljaocId == korisnikId2 && x.PrimaocId == korisnikId1)
            .ToList();

            foreach (var poruka in poruke)
            {
                poruka.Procitana = true;
            }

            _context.SaveChanges();

            return NoContent();
        }
    }
}
