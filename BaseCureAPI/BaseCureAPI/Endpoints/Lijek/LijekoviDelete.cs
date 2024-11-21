using BaseCureAPI.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Endpoints.Lijek.Delete
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

        [HttpDelete("{id}")]
        public ActionResult DeleteLijek(int id)
        {
            var lijek = _context.Lijekovis.SingleOrDefault(x => x.LijekId == id);
            if (lijek == null)
            {
                return NotFound();
            }

            _context.Lijekovis.Remove(lijek);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
