using BaseCureAPI.DB;
using BaseCureAPI.DB.Models;
using BaseCureAPI.Endpoints.Korisnik.Post;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BaseCureAPI.Endpoints.Lijek.Post
{
    [Route("lijekovi")]
    [ApiController]
    public class LijekoviController : ControllerBase
    {
        private readonly BasecureContext _context;

        public LijekoviController(BasecureContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult CreateLijek([FromForm] IFormFile slika, [FromForm] LijekoviPostReq req)
        {
            byte[] imageBytes = null;
            if (slika != null && slika.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    slika.CopyTo(memoryStream);
                    imageBytes = memoryStream.ToArray();
                }
            }

            var lijek = new Lijekovi
            {
                Naziv = req.Naziv,
                Opis = req.Opis,
                Slika = imageBytes,
                UstanovaId = req.UstanovaId,
                Cijena = req.Cijena,
                Kolicina = req.Kolicina,
                ZahtijevaRecept = req.ZahtijevaRecept
            };

            if (req.ID == 0)
            {
                int maxId = _context.Lijekovis.Any() ? _context.Lijekovis.Max(x => x.LijekId) + 1 : 1;
                lijek.LijekId = maxId;
            }
            else
            {
                lijek.LijekId = req.ID;
            }
            _context.Lijekovis.Add(lijek);

            _context.SaveChanges();

            return NoContent();
        }
    }
}
