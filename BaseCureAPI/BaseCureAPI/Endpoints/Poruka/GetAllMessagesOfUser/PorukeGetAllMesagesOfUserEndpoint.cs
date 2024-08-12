using BaseCureAPI.DB;
using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Endpoints.Poruka.GetAllMessagesOfUser
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

        [HttpGet]
        public ActionResult Get([FromQuery] int korisnikId1, [FromQuery] int korisnikId2)
        {
            var poruke = _context.Porukes
                .Where(x => (x.PosiljaocId == korisnikId1 && x.PrimaocId == korisnikId2) || (x.PosiljaocId == korisnikId2 && x.PrimaocId == korisnikId1))
                .ToList();

            return Ok(poruke);
        }
    }
}
