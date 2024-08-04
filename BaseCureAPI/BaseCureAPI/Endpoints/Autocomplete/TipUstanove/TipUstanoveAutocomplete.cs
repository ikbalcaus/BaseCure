using BaseCureAPI.DB;
using BaseCureAPI.Endpoints.Grad.GetAll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Endpoints.Autocomplete.TipUstanoveZdravstva
{
    [Route("autocomplete")]
    [ApiController]
    public class AutoCompleteController : ControllerBase
    {
        private readonly BasecureContext _context;

        public AutoCompleteController(BasecureContext context)
        {
            _context = context;
        }

        [HttpGet("tipUstanove")]
        public ActionResult GetSearchResult([FromQuery] string? naziv)
        {
            var results = _context.TipoviUstanovas
                .Where(x => x.Naziv.Contains(naziv)).Select(x => x.Naziv).Take(5).ToList();
            return Ok(results);
        }
    }
}
