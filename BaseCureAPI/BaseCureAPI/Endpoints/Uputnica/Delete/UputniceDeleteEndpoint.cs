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
        public async Task<IActionResult> DeleteTherapy([FromRoute]int id)
        {
            var therapy = await _context.Terapijes.FindAsync(id);
            if (therapy == null)
            {
                return NotFound();
            }

            _context.Terapijes.Remove(therapy);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
