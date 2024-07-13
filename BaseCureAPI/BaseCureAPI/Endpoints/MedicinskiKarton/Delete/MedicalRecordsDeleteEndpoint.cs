using BaseCureAPI.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Endpoints.MedicinskiKarton.Delete
{
    [Route("medicalRecords")]
    [ApiController]
    public class MedicinskiKartoniController : ControllerBase
    {
        private readonly BasecureContext _context;

        public MedicinskiKartoniController(BasecureContext context)
        {
            _context = context;
        }

        [HttpDelete("id")]
        public IActionResult DeleteKarton(int id)
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
