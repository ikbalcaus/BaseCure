using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using BaseCureAPI.DB;
using BaseCureAPI.Helpers;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.Filter.UstanovaZdravstva
{
    [Route("filter")]
    [ApiController]
    public class UstanoveZdravstvaController : ControllerBase
    {
        private readonly BasecureContext _context;

        public UstanoveZdravstvaController(BasecureContext context)
        {
            _context = context;
        }

        [HttpGet("ustanoveZdravstva")]
        public ActionResult GetUstanova([FromQuery] string? tipUstanove, [FromQuery] string? grad)
        {
            var ustanove = _context.UstanoveZdravstvas.OrderByDescending(x => x.UstanovaId)
                .Include(x => x.Grad)
                .Where(x => (string.IsNullOrEmpty(tipUstanove) || x.TipUstanove.Naziv == tipUstanove) && (string.IsNullOrEmpty(grad) || x.Grad.Naziv == grad))
                .Select(x => new UstanoveZdravstvaSearchRes()
                {
                    UstanovaId = x.UstanovaId,
                    Naziv = x.Naziv,
                    Grad = x.Grad.Naziv,
                    TipUstanove = x.TipUstanove.Naziv
                }).ToList();
            return Ok(ustanove);
        }
    }
}