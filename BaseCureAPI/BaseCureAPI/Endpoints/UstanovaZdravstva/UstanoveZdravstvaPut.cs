﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using BaseCureAPI.DB;
using BaseCureAPI.Endpoints.UstanovaZdravstva;
using BaseCureAPI.Helpers;

namespace BaseCureAPI.Endpoints.UstanovaZdravstva.Put
{
    [Route("ustanoveZdravstva")]
    [ApiController]
    public class UstanoveZdravstvaController : ControllerBase
    {
        private readonly BasecureContext _context;

        public UstanoveZdravstvaController(BasecureContext context)
        {
            _context = context;
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUstanova(int id, [FromForm] UstanoveZdravstvaPutReq ustanovareq)
        {
            var ustanova = _context.UstanoveZdravstvas.SingleOrDefault(x => x.UstanovaId == id);
            if (ustanova == null)
                return NotFound();

            var grad = _context.Gradovis.SingleOrDefault(x => x.Naziv == ustanovareq.Grad);

            if(grad == null)
            {
                return BadRequest(new { message = "Grad ne postoji" });
            }

            ustanova.Naziv = ustanovareq.Naziv;
            ustanova.Adresa = ustanovareq.Adresa;
            ustanova.MailAdresa = ustanovareq.MailAdresa;
            ustanova.BrojTelefona = ustanovareq.BrojTelefona;
            ustanova.CijenaDostave = ustanovareq.CijenaDostave;
            ustanova.Opis = ustanovareq.Opis;
            ustanova.Grad = grad;

            if (ustanovareq.Slika != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    ustanovareq.Slika.CopyTo(memoryStream);
                    ustanova.Slika = memoryStream.ToArray();
                }
            }

            _context.UstanoveZdravstvas.Update(ustanova);
            _context.SaveChanges();

            return NoContent();
        }
    }

    public class UstanoveZdravstvaPutReq
    {
        public string? Naziv { get; set; }
        public string? Adresa { get; set; }
        public string? BrojTelefona { get; set; }
        public string? MailAdresa { get; set; }
        public string? Opis { get; set; }
        public float? CijenaDostave { get; set; }
        public IFormFile? Slika { get; set; }
        public string? Grad { get; set; }
    }
}