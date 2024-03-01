using BaseCureAPI.DB;
using BaseCureAPI.DB.Models;
using BaseCureAPI.Endpoints.Korisnik.Post;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Endpoints.Lijek.Post
{
    [Route("lijekovi")]
    [ApiController]
    public class LijekoviPostEndpoints : ControllerBase
    {
        private readonly BasecureContext _context;

        public LijekoviPostEndpoints(BasecureContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateLijek([FromBody] LijekoviPostReq req)
        {

            if (req == null)
                return BadRequest("User data is null");

            var lijek = new Lijekovi
            {
                NazivLijeka = req.NazivLijeka,
                OpisLijeka = req.OpisLijeka,
                SlikaLijeka = req.SlikaLijeka,
                UstanovaId = req.UstanovaId,
                ZahtijevaRecept = req.ZahtijevaRecept
            };

            if (req.ID == 0)
            {
                int maxId = _context.Lijekovis.Any() ? _context.Lijekovis.Max(x => x.KorisnikId) + 1 : 1;
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
