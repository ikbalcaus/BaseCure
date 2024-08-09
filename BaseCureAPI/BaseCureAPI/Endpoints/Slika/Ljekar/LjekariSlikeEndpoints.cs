using BaseCureAPI.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Endpoints.Slika.Ljekar
{
    [Route("slika")]
    [ApiController]
    public class LjekariController : ControllerBase
    {
        private readonly BasecureContext _context;

        public LjekariController(BasecureContext context)
        {
            _context = context;
        }

        [HttpGet("ljekari/{id}")]
        public IActionResult GetImage(int id)
        {
            var image = _context.Ljekaris
                .Where(x => x.LjekarId == id)
                .Select(x => x.Slika)
                .FirstOrDefault();

            if (image == null)
            {
                return NotFound();
            }

            return File(image, "image/jpeg");
        }
    }
}
