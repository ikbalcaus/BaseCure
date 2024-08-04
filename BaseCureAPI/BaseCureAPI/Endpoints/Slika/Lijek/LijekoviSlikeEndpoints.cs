using BaseCureAPI.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Endpoints.Slika.Lijek
{
    [Route("slika")]
    [ApiController]
    public class LijekoviController : ControllerBase
    {
        private readonly BasecureContext _context;

        public LijekoviController(BasecureContext context)
        {
            _context = context;
        }

        [HttpGet("lijekovi/{id}")]
        public IActionResult GetImage(int id)
        {
            var image = _context.Lijekovis
                .Where(x => x.LijekId == id)
                .Select(x => x.Slika)
                .FirstOrDefault();

            if (image == null)
            {
                return NotFound();
            }

            return File(image, "image/jpeg");
        }

        [HttpPost("lijekovi/{id}")]
        public IActionResult PostImage(int id, [FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            var lijek = _context.Lijekovis.Find(id);
            if (lijek == null)
            {
                return NotFound();
            }

            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                lijek.Slika = memoryStream.ToArray();
            }

            _context.Lijekovis.Update(lijek);
            _context.SaveChanges();

            return Ok();
        }

    }
}
