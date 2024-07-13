using BaseCureAPI.DB;
using BaseCureAPI.Endpoints.Grad.GetAll;
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
        public ActionResult GetSearchResult([FromQuery] string naziv) {
            if (string.IsNullOrWhiteSpace(naziv))
            {
                return BadRequest("Search term is required.");
            }

            var results = _context.Gradovis
                .Where(x => x.Naziv.Contains(naziv))
                .Select(x => new GradoviGetAllRes
                {
                    GradId = x.GradId,
                    Naziv = x.Naziv
                })
                .Take(5) // Limit the number of results
                .ToList();

            return Ok(results);
        }
    }
}
