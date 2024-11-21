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

        [HttpPut("{id}")]
        public ActionResult EditTherapy([FromRoute] int id, object therapy)
        {
            var existingTherapy = _context.Terapijes.SingleOrDefault(x => x.TerapijaId == id);
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
                _context.SaveChanges();
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
