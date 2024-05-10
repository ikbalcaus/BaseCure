using BaseCureAPI.DB;
using BaseCureAPI.DB.Models;
using BaseCureAPI.Endpoints.Narudzba.Post;
using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Endpoints.Narudzba.Post
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

        [HttpPost]
        public ActionResult CreateNarudzba([FromBody] NaruzbaPostReq req)
        {
            var narudzba = new Narudzbe
            {
                KorisnikId = req.KorisnikId,
                LijekId = req.LijekId,
                DatumVrijeme = DateTime.Now,
                Status = "neaktivno",
                RedniBroj = 0
            };
            narudzba.NarudzbaId = _context.Narudzbes.Any() ? _context.Narudzbes.Max(x => x.NarudzbaId) + 1 : 1;
            _context.Narudzbes.Add(narudzba);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
