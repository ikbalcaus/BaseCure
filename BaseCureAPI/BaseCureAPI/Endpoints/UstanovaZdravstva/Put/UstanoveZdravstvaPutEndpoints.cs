using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using BaseCureAPI.DB;
using BaseCureAPI.Endpoints.UstanovaZdravstva;
using BaseCureAPI.Helpers;

namespace BaseCureAPI.Endpoints.UstanovaZdravstva.Put
{
    [Route("ustanveZdravstva")]
    [ApiController]
    public class UstanoveZdravstvaController : ControllerBase
    {
        private readonly BasecureContext _context;

        public UstanoveZdravstvaController(BasecureContext context)
        {
            _context = context;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUstanova(int id, [FromBody] UstanoveZdravstvaPutReq ustanovareq, IFormFile image)
        {
            var ustanova = _context.UstanoveZdravstvas.Find(id);
            if (ustanova == null)
                return NotFound();

            // Update ustanova properties
            ustanova.Naziv = ustanovareq.Naziv;
            ustanova.Grad = ustanovareq.Grad;
            ustanova.Adresa = ustanovareq.Adresa;
            ustanova.MailAdresa = ustanovareq.MailAdresa;
            ustanova.BrojTelefona = ustanovareq.BrojTelefona;
            ustanova.CijenaDostave = ustanovareq.CijenaDostave;
            ustanova.Opis = ustanovareq.Opis;

            if (image != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    image.CopyTo(memoryStream);
                    ustanova.ImageData = memoryStream.ToArray();
                }
            }

            _context.UstanoveZdravstvas.Update(ustanova);
            _context.SaveChanges();

            return NoContent();
        }
    }
}