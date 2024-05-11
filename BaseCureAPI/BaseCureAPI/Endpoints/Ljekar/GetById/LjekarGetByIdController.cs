using BaseCureAPI.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Endpoints.Ljekar.GetById
{
    [Route("ljekari")]
    [ApiController]
    public class LjekarGetByIdController : ControllerBase
    {
        private readonly BasecureContext _context;

        public LjekarGetByIdController(BasecureContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Get([FromQuery] int ljekarid)
        {
            var ljekar = _context.Ljekaris.Where(x => x.LjekarId == ljekarid)
                .Select(x => new LjekarGetByIdRes()
                {
                    LjekarId = x.LjekarId,
                    Specijalizacija = x.Specijalizacija,
                    Korisnik = x.Korisnik,
                    Ustanova = x.Ustanova
                }).FirstOrDefault();

            return Ok(ljekar);
        }
    }
}
