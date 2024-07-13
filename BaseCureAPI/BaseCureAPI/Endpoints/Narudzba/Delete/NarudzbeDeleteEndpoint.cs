using BaseCureAPI.DB;
using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Endpoints.Narudzba.Delete
{
    [Route("narudzbe")]
    [ApiController]
    public class NaruzbeController : ControllerBase
    {
        private readonly BasecureContext _context;

        public NaruzbeController(BasecureContext context)
        {
            _context = context;
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteNarudzba([FromRoute] int id)
        {
            var narudzba = _context.Narudzbes.Find(id);
            if (narudzba == null)
            {
                return NotFound();
            }

            _context.Narudzbes.Remove(narudzba);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
