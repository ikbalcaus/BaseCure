<<<<<<< HEAD
﻿﻿using BaseCureAPI.DB;
=======
﻿using BaseCureAPI.DB;
>>>>>>> parent of e1da335 (Revert "Segmented Korisnici API routes into individual files")
using BaseCureAPI.DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.Korisnik.Put
{
    [Route("korisnici")]
    [ApiController]
    public class KorisniciPutEndpoint : ControllerBase
    {
        private readonly BasecureContext _context;

        public KorisniciPutEndpoint(BasecureContext context)
        {
            _context = context;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateKorisnik(int id, [FromBody] KorisniciPutRes korisnikRes)
        {
            var korisnik = _context.Korisnicis.Find(id);
            if (korisnik == null)
            {
                return NotFound();
            }
            korisnik.KorisnickoIme = korisnikRes.KorisnickoIme;
            korisnik.HashLozinke = korisnikRes.HashLozinke;
            korisnik.Ime = korisnikRes.Ime;
            korisnik.Prezime = korisnikRes.Prezime;
            // Update other properties as needed

            _context.SaveChanges();

            return NoContent();
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> parent of e1da335 (Revert "Segmented Korisnici API routes into individual files")
