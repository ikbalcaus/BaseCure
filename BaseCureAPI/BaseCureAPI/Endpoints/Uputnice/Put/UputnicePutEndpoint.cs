using BaseCureAPI.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.Uputnice.Put
{
    [Route("uputnice")]
    [ApiController]
    public class UputnicePutEndpoint : ControllerBase
    {
        private readonly BasecureContext _context;

        public UputnicePutEndpoint(BasecureContext context)
        {
            _context = context;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditTherapy(int id, object therapy)
        {
            // Retrieve the therapy object from the database
            var existingTherapy = await _context.Terapijes.FindAsync(id);
            if (existingTherapy == null)
            {
                return NotFound();
            }

            // Update properties of the existing therapy object
            // Assuming that the therapy object has properties TherapyName, StartDate, EndDate
            var therapyProperties = therapy.GetType().GetProperties();
            foreach (var property in therapyProperties)
            {
                var existingProperty = existingTherapy.GetType().GetProperty(property.Name);
                if (existingProperty != null)
                {
                    existingProperty.SetValue(existingTherapy, property.GetValue(therapy));
                }
            }

            // Update the modified therapy in the database
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
