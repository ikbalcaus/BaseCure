using BaseCureAPI.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.Uputnica.Put
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

        [HttpPut()]
        public async Task<IActionResult> EditTherapy([FromQuery]int id, object therapy)
        {
            var existingTherapy = await _context.Terapijes.FindAsync(id);
            if (existingTherapy == null)
            {
                return NotFound();
            }

            var therapyProperties = therapy.GetType().GetProperties();
            foreach (var property in therapyProperties)
            {
                var existingProperty = existingTherapy.GetType().GetProperty(property.Name);
                if (existingProperty != null)
                {
                    existingProperty.SetValue(existingTherapy, property.GetValue(therapy));
                }
            }

            _context.Entry(existingTherapy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Terapijes.Any(t => t.TerapijaId == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
    }
}
