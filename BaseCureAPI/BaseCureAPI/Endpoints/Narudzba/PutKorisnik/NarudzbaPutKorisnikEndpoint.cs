﻿using BaseCureAPI.DB;
using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Endpoints.Narudzba.PutKorisnik
{
    [Route("narudzbe")]
    [ApiController]
    public class NaruzbeController : ControllerBase
    {
        private readonly BasecureContext _context;

        public NaruzbeController(BasecureContext context)
        {
            _context = context;
        }

        [HttpPut("korisnik/{korisnikId}")]
        public ActionResult UpdateNarudzba([FromRoute] int korisnikId)
        {
            var narudzbe = _context.Narudzbes
                .Where(x => x.KorisnikId == korisnikId && x.Status == "neaktivno");
            foreach (var narudzba in narudzbe)
            {
                narudzba.Status = "aktivno";
            }
            _context.SaveChanges();
            return NoContent();
        }
    }
}
