using BaseCureAPI.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Endpoints.Ljekar.GetAllByUstanovaZdravstva
{
    [Route("ljekari/uputnice")]
    [ApiController]
    public class LjekariController : ControllerBase
    {
        private readonly BasecureContext _context;

        public LjekariController(BasecureContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Get([FromQuery] int ustanovaid)
        {
            var ljekari = _context.Ljekaris.Where(x => x.UstanovaId == ustanovaid)
                .Select(x => new LjekarGetAllByUstanovaZdravstvaRes()
                {
                    Specijalizacija = x.Specijalizacija,
                    Korisnik = x.Korisnik
                }).ToList();

            return Ok(new LjekarGetAllByUstanovaZdravstvaResList
            {
                Ljekari = ljekari
            });
        }
    }
}
