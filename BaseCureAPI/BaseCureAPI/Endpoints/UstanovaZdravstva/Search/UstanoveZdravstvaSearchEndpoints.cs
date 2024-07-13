using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using BaseCureAPI.DB;
using BaseCureAPI.Endpoints.UstanovaZdravstva;
using BaseCureAPI.Helpers;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.UstanovaZdravstva.Search
{
    [Route("ustanoveZdravstva")]
    [ApiController]
    public class UstanoveZdravstvaController : ControllerBase
    {
        private readonly BasecureContext _context;

        public UstanoveZdravstvaController(BasecureContext context)
        {
            _context = context;
        }

        [HttpGet("search")]
        public ActionResult GetUstanova([FromQuery] UstanoveZdravstvaSearchReq req)
        {
            var ustanove = _context.UstanoveZdravstvas.OrderByDescending(x => x.UstanovaId)
                .Include(x => x.Grad)
                .Where(x => (string.IsNullOrEmpty(req.Naziv) || x.Naziv.Contains(req.Naziv)) && (string.IsNullOrEmpty(req.Grad) || x.Grad.Naziv == req.Grad))
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