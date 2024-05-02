using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using BaseCureAPI.DB;
using BaseCureAPI.Endpoints.UstanovaZdravstva;
using BaseCureAPI.Helpers;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.UstanovaZdravstva.GetByParams
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

        [HttpGet]
        public ActionResult<UstanoveZdravstvaGetByParamsRes> GetUstanovaZdravstva([FromQuery]int id)
        {
            var ustanovaZdravstva = _context.UstanoveZdravstvas.OrderByDescending(x => x.UstanovaId)
                .Where(x => x.UstanovaId == id)
                .Include(x => x.Grad)
                .Select(x => new UstanoveZdravstvaGetByParamsRes()
                {
                    Naziv = x.Naziv,
                    Adresa = x.Adresa,
                    KontaktBroj = x.KontaktBroj,
                    Email = x.Email,
                    Grad = x.Grad.Naziv,
                    TipUstanove = x.TipUstanove.Naziv
                }).Single();

            return ustanovaZdravstva;
        }
    }
}