using BaseCureAPI.DB;
using BaseCureAPI.DB.Models;
using BaseCureAPI.Endpoints.Korisnik.Post;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.MedicalRecords.Post
{
    [Route("medicalRecords")]
    [ApiController]
    public class MedicalRecordsPostEndpoint : ControllerBase
    {
        private readonly BasecureContext _context;

        public MedicalRecordsPostEndpoint(BasecureContext context)
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
                .Where(p => p.Korisnik.Ime == req.ImePacijenta)
                .Select(p => (int?)p.PacijentId)
                .FirstOrDefault();

            if (!pacijentId.HasValue)
            {
                // Handle the case where the PacijentId is not found for the given patient name
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
