using BaseCureAPI.DB;
using BaseCureAPI.DB.Models;
using BaseCureAPI.Endpoints.Korisnik.Post;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.MedicinskiKarton.Post
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

        [HttpPost]
        public IActionResult CreateKarton([FromBody] MedicalRecordsPostReq req)
        {
            if (req == null)
                return BadRequest("User data is null");

            Console.WriteLine($"Received patient name: {req.ImePacijenta}");

            int? pacijentId = _context.Pacijentis.Include(x => x.Korisnik)
                .Where(x => x.Korisnik.Ime == req.ImePacijenta)
                .Select(x => (int?)x.PacijentId)
                .FirstOrDefault();

            if (!pacijentId.HasValue)
            {
                return BadRequest("PacijentId not found for the provided ImePacijenta.");
            }

            var karton = new ZdravstveniKartoni
            {
                DatumIzdavanja = req.DatumIzdavanja,
                Sadrzaj = req.Sadrzaj,
                PacijentId = pacijentId.Value,
            };

            if (req.ID == 0)
            {
                int maxId = _context.ZdravstveniKartonis.Any() ? _context.ZdravstveniKartonis.Max(x => x.KartonId) + 1 : 1;
                karton.KartonId = maxId;
            }
            else
            {
                karton.KartonId = req.ID;
            }
            _context.ZdravstveniKartonis.Add(karton);

            _context.SaveChanges();

            return NoContent();
        }
    }
}
