﻿using System.Text.Json.Serialization;
using BaseCureAPI.DB;
using BaseCureAPI.Endpoints.Filter.Lijek;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BaseCureAPI.DB.Models;

namespace BaseCureAPI.Endpoints.Filter.Ljekar
{
    [Route("filter")]
    [ApiController]
    public class LjekariController : ControllerBase
    {
        private readonly BasecureContext _context;

        public LjekariController(BasecureContext context)
        {
            _context = context;
        }

        [HttpGet("ljekari/{ustanovaId}")]
        public ActionResult Get([FromRoute] int ustanovaId, [FromQuery] string? imePrezime, [FromQuery] string? specijalizacija)
        {
            var ljekari = _context.Ljekaris
            .Include(x => x.Korisnik)
            .Where(x => x.UstanovaId == ustanovaId && (string.IsNullOrEmpty(imePrezime) || ((x.Korisnik.Ime + " " + x.Korisnik.Prezime).Contains(imePrezime)) || (x.Korisnik.Prezime + " " + x.Korisnik.Ime).Contains(imePrezime)) && (string.IsNullOrEmpty(specijalizacija) || x.Specijalizacija.Contains(specijalizacija)))
                .Select(x => new LjekariSearchRes()
                {
                    LjekarId = x.LjekarId,
                    Specijalizacija = x.Specijalizacija,
                    Korisnik = x.Korisnik
                }).ToList();

            return Ok(ljekari);
        }
    }

    public class LjekariSearchRes
    {
        public int? LjekarId { get; set; }
        public string? Specijalizacija { get; set; }
        [JsonIgnore]
        public Korisnici Korisnik { get; set; }
        public int KorisnikId => Korisnik.KorisnikId;
        public string ImePrezime => $"{Korisnik?.Ime} {Korisnik?.Prezime}";
    }
}