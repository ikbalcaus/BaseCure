using BaseCureAPI.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Endpoints.Slika.UstanovaZdravstva
{
    [Route("slika")]
    [ApiController]
    public class UstanoveZdravstvaController : ControllerBase
    {
        private readonly BasecureContext _context;

        public UstanoveZdravstvaController(BasecureContext context)
        {
            _context = context;
        }

        [HttpGet("ustanoveZdravstva/{id}")]
        public IActionResult GetImage(int id)
        {
            var image = _context.UstanoveZdravstvas
                .Where(x => x.UstanovaId == id)
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
