using BaseCureAPI.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.Ljekar.GetById
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

        [HttpGet("{id}")]
        public ActionResult Get([FromRoute] int id)
        {
            var ljekar = _context.Ljekaris.Where(x => x.LjekarId == id)
                .Include(x => x.Korisnik)
                .ThenInclude(x => x.Grad)
                .Select(x => new LjekarGetByIdRes()
                {
                    LjekarId = x.LjekarId,
                    Ime = x.Korisnik.Ime,
                    Prezime = x.Korisnik.Prezime,
                    Specijalizacija = x.Specijalizacija,
                    MailAdresa = x.Korisnik.MailAdresa,
                    Adresa = x.Korisnik.Adresa,
                    Grad = x.Korisnik.Grad.Naziv
                }).FirstOrDefault();

            return Ok(ljekar);
        }
    }
}
