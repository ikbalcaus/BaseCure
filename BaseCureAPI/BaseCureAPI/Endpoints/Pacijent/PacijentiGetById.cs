﻿using BaseCureAPI.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Endpoints.Pacijent.GetById
{
    [Route("/pacijenti")]
    [ApiController]
    public class PacijentiController : ControllerBase
    {
        private readonly BasecureContext _context;

        public PacijentiController(BasecureContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public ActionResult Get([FromRoute] int id)
        {
            var pacijent = _context.Pacijentis
                .Where(x => x.PacijentId == id)
                .Select(x => new PacijentiGetByIdRes
                {
                    Tezina = x.Tezina,
                    Visina = x.Visina,
                    KrvnaGrupa = x.KrvnaGrupa,
                    PritisakSistolicki = x.PritisakSistolicki,
                    PritisakDistolicki = x.PritisakDistolicki,
                    Pulz = x.Pulz,
                    Alergije = x.Alergije,
                    TrenutneBolesti = x.TrenutneBolesti,
                    RanijeBolesti = x.RanijeBolesti,
                    Lijekovi = x.Lijekovi,
                    PorodicnaAnamneza = x.PorodicnaAnamneza,
                    NavikePonasanja = x.NavikePonasanja
                }).ToList();
            return Ok(pacijent);
        }
    }

    public class PacijentiGetByIdRes
    {
        public decimal? Tezina { get; set; }
        public decimal? Visina { get; set; }
        public string? KrvnaGrupa { get; set; }
        public int? PritisakSistolicki { get; set; }
        public int? PritisakDistolicki { get; set; }
        public int? Pulz { get; set; }
        public string? Alergije { get; set; }
        public string? TrenutneBolesti { get; set; }
        public string? RanijeBolesti { get; set; }
        public string? Lijekovi { get; set; }
        public string? PorodicnaAnamneza { get; set; }
        public string? NavikePonasanja { get; set; }
    }
}
