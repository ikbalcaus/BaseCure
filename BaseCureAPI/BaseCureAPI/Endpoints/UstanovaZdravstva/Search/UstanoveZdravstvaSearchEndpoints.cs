using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using BaseCureAPI.DB;
using BaseCureAPI.Endpoints.UstanovaZdravstva;
using BaseCureAPI.Helpers;

namespace BaseCureAPI.Endpoints.UstanovaZdravstva.Search
{
    [Route("ustanveZdravstva")]
    [ApiController]
    public class UstanoveZdravstvaController : ControllerBase
    {
        private readonly BasecureContext _context;

        public UstanoveZdravstvaController(BasecureContext context)
        {
            _context = context;
        }

        [HttpPost("search")]
        public ActionResult<UstanoveZdravstvaSearchReq> GetUstanova([FromBody] UstanoveZdravstvaSearchReq req)
        {
            var ustanove = _context.UstanoveZdravstvas.OrderByDescending(x => x.UstanovaId)
                .Where(x => x.Naziv.Contains(req.Naziv) && (x.Grad == req.Grad || req.Grad == ""))
                .Select(x => new UstanoveZdravstvaSearchReq()
                {
                    UstanovaId = x.UstanovaId,
                    Naziv = x.Naziv,
                    Grad = x.Grad,
                }).ToList();
            return Ok(ustanove);
        }
    }
}