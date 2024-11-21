using BaseCureAPI.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Endpoints.Uputnica.Delete
{
    [Route("uputnice")]
    [ApiController]
    public class UputniceController : ControllerBase
    {
        private readonly BasecureContext _context;

        public UputniceController(BasecureContext context)
        {
            _context = context;
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTherapy([FromRoute]int id)
        {
            var therapy = _context.Terapijes.Find(id);
            if (therapy == null)
            {
                return NotFound();
            }

            _context.Terapijes.Remove(therapy);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
