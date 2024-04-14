using BaseCureAPI.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Endpoints.MedicalRecords.Delete
{
    [Route("medicalRecords")]
    [ApiController]
    public class MedicalRecordsController : ControllerBase
    {
        private readonly BasecureContext _context;

        public MedicalRecordsController(BasecureContext context)
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
