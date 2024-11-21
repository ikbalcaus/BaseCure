using BaseCureAPI.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Endpoints.Karton.Delete
{
    [Route("kartoni")]
    [ApiController]
    public class KartoniController : ControllerBase
    {
        private readonly BasecureContext _context;

        public KartoniController(BasecureContext context)
        {
            _context = context;
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteKarton([FromRoute] int id)
        {
            var karton = _context.ZdravstveniKartonis.Find(id);
            if (karton == null)
            {
                return NotFound();
            }

            _context.ZdravstveniKartonis.Remove(karton);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
