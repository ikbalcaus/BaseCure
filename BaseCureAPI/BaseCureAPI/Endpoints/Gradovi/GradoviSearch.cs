using BaseCureAPI.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Endpoints.Search
{
    [Route("gradovi")]
    [ApiController]
    public class GradoviController : ControllerBase
    {
        private readonly BasecureContext _context;

        public GradoviController(BasecureContext context)
        {
            _context = context;
        }

        [HttpGet("search")]
        public ActionResult GetSearchResult([FromQuery] string searchTerm) {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return BadRequest("Search term is required.");
            }

            var results = _context.Gradovis
                .Where(g => g.Naziv.Contains(searchTerm))
                .Select(g => g.Naziv)
                .Take(5) // Limit the number of results
                .ToList();

            return Ok(results);
        }
    }
}
