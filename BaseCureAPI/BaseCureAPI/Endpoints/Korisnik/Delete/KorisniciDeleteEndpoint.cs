using BaseCureAPI.DB;
using BaseCureAPI.DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.Korisnik.Delete
{
    [Route("korisnici")]
    [ApiController]
    public class KorisniciDeleteEndpoint : ControllerBase
    {
        private readonly BasecureContext _context;

        public KorisniciDeleteEndpoint(BasecureContext context)
        {
            _context = context;
        }

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
<<<<<<< HEAD
}
=======
}
>>>>>>> parent of e1da335 (Revert "Segmented Korisnici API routes into individual files")
