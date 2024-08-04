using BaseCureAPI.DB;
using BaseCureAPI.DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;

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
        public ActionResult CreateLijek([FromForm] LijekoviPostReq req)
        {
            byte[] imageBytes = null;

            if (req.Slika != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    req.Slika.CopyTo(memoryStream);
                    imageBytes = memoryStream.ToArray();
                }
            }

            var lijek = new Lijekovi
            {
                Naziv = req.Naziv,
                Opis = req.Opis,
                Slika = imageBytes,
                Cijena = req.Cijena,
                Kolicina = req.Kolicina,
                ZahtijevaRecept = req.ZahtijevaRecept,
                UstanovaId = req.UstanovaId
            };

            int maxId = _context.Lijekovis.Any() ? _context.Lijekovis.Max(x => x.LijekId) + 1 : 1;
            lijek.LijekId = maxId;

            _context.Lijekovis.Add(lijek);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
