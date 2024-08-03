using BaseCureAPI.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.Lijek.Put
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

        [HttpPut("{id}")]
        public ActionResult PutLijek(int id, [FromForm] LijekoviPutReq req)
        {
            var lijek = _context.Lijekovis.SingleOrDefault(x => x.LijekId == id);
            if (lijek == null)
            {
                return NotFound();
            }
            lijek.Naziv = req.Naziv;
            lijek.Opis = req.Opis;
            lijek.ZahtijevaRecept = req.ZahtijevaRecept;
            lijek.Cijena = req.Cijena;
            lijek.Kolicina = req.Kolicina;

            if (req.Slika != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    req.Slika.CopyTo(memoryStream);
                    lijek.Slika = memoryStream.ToArray();
                }
            }

            _context.SaveChanges();

            return NoContent();
        }
    }
}
