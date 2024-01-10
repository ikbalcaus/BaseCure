using BaseCureAPI.DB;
using BaseCureAPI.DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.Korisnik.Post
{
    [Route("korisnici")]
    [ApiController]
    public class KorisniciPostEndpoint : ControllerBase
    {
        private readonly BasecureContext _context;

        public KorisniciPostEndpoint(BasecureContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<int> CreateKorisnik([FromBody] KorisniciPostReq req)
        {

            if (req == null)
                return BadRequest("User data is null");
            var korisnik = new Korisnici
            {
                Ime = req.Ime,
                Prezime = req.Prezime,
                KorisnickoIme = req.KorisnickoIme,
                HashLozinke = req.HashLozinke
            };

            if (req.ID == 0)
            {
                int maxId = _context.Korisnicis.Any() ? _context.Korisnicis.Max(x => x.KorisnikId) + 1 : 1;
                korisnik.KorisnikId = maxId;
            }
            else
            {
                korisnik.KorisnikId = req.ID;
            }
            _context.Korisnicis.Add(korisnik);

            _context.SaveChanges();

            return Ok(korisnik.KorisnikId);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> parent of e1da335 (Revert "Segmented Korisnici API routes into individual files")
