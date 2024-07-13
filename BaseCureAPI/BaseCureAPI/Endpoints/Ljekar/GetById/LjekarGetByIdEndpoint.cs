using BaseCureAPI.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Endpoints.Ljekar.GetById
{
    [Route("ljekar")]
    [ApiController]
    public class LjekariController : ControllerBase
    {
        private readonly BasecureContext _context;

        public LjekariController(BasecureContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult Get([FromRoute] int id)
        {
            var ljekar = _context.Ljekaris.Where(x => x.LjekarId == id)
                .Select(x => new LjekarGetByIdRes()
                {
                    LjekarId = x.LjekarId,
                    Specijalizacija = x.Specijalizacija,
                    Opis = x.Opis,
                    Korisnik = x.Korisnik,
                    UstanovaZdravstva = x.Ustanova,
                    grad = x.Korisnik.Grad
                }).FirstOrDefault();

            return Ok(ljekar);
        }
    }
}
