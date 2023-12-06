using BaseCureAPI.DB;
using BaseCureAPI.DB.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseCureAPI.Endpoints
{
    [Route("korisnici")]
    [ApiController]
    public class KorisniciEndpoints : ControllerBase
    {

        private readonly BaseCureContext _context;

        public KorisniciEndpoints(BaseCureContext context)
        {
            _context = context;
        }

        // GET: korisnici
        [HttpGet]
        public ActionResult<IEnumerable<Korisnici>> Get()
        {
            return _context.Korisnicis.ToList();
        }

        // GET korisnici/5
        [HttpGet("{id}")]
        public ActionResult<Korisnici> GetKorisnik(int id)
        {
            var korisnik = _context.Korisnicis.Find(id);

            if (korisnik == null)
            {
                return NotFound();
            }

            return korisnik;
        }

        [HttpPost]
        public IActionResult CreateKorisnik([FromBody] Korisnici korisnik)
        {
            _context.Korisnicis.Add(korisnik);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetKorisnik), new { id = korisnik.KorisnikId }, korisnik);
        }

        // PUT: korisnici/5
        [HttpPut("{id}")]
        public IActionResult UpdateKorisnik(int id, [FromBody] Korisnici korisnik)
        {
            if (id != korisnik.KorisnikId)
            {
                return BadRequest();
            }

            _context.Entry(korisnik).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: korisnici/5
        [HttpDelete("{id}")]
        public IActionResult DeleteKorisnik(int id)
        {
            var korisnik = _context.Korisnicis.Find(id);
            if (korisnik == null)
            {
                return NotFound();
            }

            _context.Korisnicis.Remove(korisnik);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
