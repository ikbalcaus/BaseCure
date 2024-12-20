﻿using BaseCureAPI.DB;
using BaseCureAPI.Endpoints.Narudzba.GetKorisnik;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.Narudzba.GetApotekaDetalji
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

        [HttpGet("apoteka/{ustanovaId}/detalji")]
        public ActionResult GetNarudzbe([FromRoute] int ustanovaId, [FromQuery] string status, [FromQuery] int redniBroj)
        {
            var narudzbe = _context.Narudzbes
                .Include(x => x.Grad)
                .Include(x => x.Korisnik)
                .Include(x => x.Lijek)
                    .ThenInclude(x => x.Ustanova)
                .Where(x => x.Lijek.UstanovaId == ustanovaId && x.Status == status && x.RedniBroj == redniBroj && (x.Status == "aktivno" || x.Status == "isporuceno"))
                .Select(x => new NarudzbeGetApotekaDetaljiRes
                {
                    NarudzbaId = x.NarudzbaId,
                    KorisnikId = x.KorisnikId,
                    ImePrezime = x.ImePrezime,
                    BrojTelefona = x.BrojTelefona,
                    Grad = x.Grad.Naziv,
                    Adresa = x.Adresa,
                    MailAdresa = x.Mailadresa,
                    LijekId = x.LijekId,
                    Naziv = x.Lijek.Naziv,
                    Opis = x.Lijek.Opis,
                    Cijena = x.Lijek.Cijena,
                    CijenaDostave = x.Lijek.Ustanova.CijenaDostave,
                    Status = x.Status
                })
                .ToList();
            return Ok(narudzbe);
        }
    }

    public class NarudzbeGetApotekaDetaljiRes
    {
        public int? NarudzbaId { get; set; }
        public int? KorisnikId { get; set; }
        public string? ImePrezime { get; set; }
        public string? BrojTelefona { get; set; }
        public string? Grad { get; set; }
        public string? Adresa { get; set; }
        public string? MailAdresa { get; set; }
        public int? LijekId { get; set; }
        public string? Naziv { get; set; }
        public string? Opis { get; set; }
        public double? Cijena { get; set; }
        public double? CijenaDostave { get; set; }
        public string? Status { get; set; }
    }
}
