﻿using BaseCureAPI.DB;
using BaseCureAPI.Endpoints.Filter.UstanovaZdravstva;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.Filter.Lijek
{
    [Route("filter")]
    [ApiController]
    public class LijekoviController : ControllerBase
    {
        private readonly BasecureContext _context;

        public LijekoviController(BasecureContext context)
        {
            _context = context;
        }

        [HttpGet("lijekovi/{ustanovaId}")]
        public ActionResult GetLijekoviByParams([FromRoute] int ustanovaId, [FromQuery] string? naziv, [FromQuery] string? opis)
        {
            var lijekovi = _context.Lijekovis
                .Where(x => x.UstanovaId == ustanovaId && (string.IsNullOrEmpty(naziv) || x.Naziv.Contains(naziv)) && (string.IsNullOrEmpty(opis) || x.Opis.Contains(opis)))
                .Select(x => new LijekoviSearchRes()
                {
                    LijekId = x.LijekId,
                    Naziv = x.Naziv,
                    Opis = x.Opis,
                    Cijena = x.Cijena,
                    ZahtijevaRecept = x.ZahtijevaRecept,
                    Kolicina = x.Kolicina
                }).ToList();
            return Ok(lijekovi);
        }
    }

    public class LijekoviSearchRes
    {
        public int LijekId { get; set; }
        public string? Naziv { get; set; }
        public bool? ZahtijevaRecept { get; set; }
        public string? Opis { get; set; }
        public int? Kolicina { get; set; }
        public double? Cijena { get; set; }
    }
}
