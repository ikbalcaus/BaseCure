﻿using BaseCureAPI.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.Narudzba.GetKorisnik
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

        [HttpGet("korisnik/{korisnikId}")]
        public ActionResult GetNarudzbe([FromRoute] int korisnikId)
        {
            var narudzbe = _context.Narudzbes
                .Include(x => x.Korisnik)
                .Include(x => x.Lijek)
                .ThenInclude(x => x.Ustanova)
                .Where(x => x.KorisnikId == korisnikId && x.Status == "neaktivno")
                .Select(x => new NarudzbeGetKorisnikRes
                {
                    NarudzbaId = x.NarudzbaId,
                    KorisnikId = x.KorisnikId,
                    LijekId = x.LijekId,
                    Naziv = x.Lijek.Naziv,
                    NazivUstanove = x.Lijek.Ustanova.Naziv,
                    Cijena = x.Lijek.Cijena,
                    CijenaDostave = x.Lijek.Ustanova.CijenaDostave,
                    Status = x.Status
                })
                .ToList();
            return Ok(narudzbe);
        }
    }
}
