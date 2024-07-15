using BaseCureAPI.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Endpoints.Ljekar.GetAllByUstanovaZdravstva
{
    [Route("ljekari")]
    [ApiController]
    public class LjekariController : ControllerBase
    {
        private readonly BasecureContext _context;

        public LjekariController(BasecureContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Get([FromQuery] int ustanovaId)
        {
            var ljekari = _context.Ljekaris/*.Where(x => x.UstanovaId == ustanovaId)*/
                .Select(x => new LjekarGetAllByUstanovaZdravstvaRes()
                {
                    LjekarId = x.LjekarId,
                    Specijalizacija = x.Specijalizacija,
                    //Korisnik = x.Korisnik
                }).ToList();

            return Ok(ljekari);
        }
    }
}
