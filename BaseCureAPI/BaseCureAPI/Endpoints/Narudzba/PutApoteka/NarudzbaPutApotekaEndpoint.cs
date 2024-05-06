using BaseCureAPI.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.Narudzba.PutApoteka
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

        [HttpPut("apoteka/{ustanovaId}/korisnik/{redniBroj}")]
        public ActionResult UpdateNarudzba([FromRoute] int ustanovaId, [FromRoute] int redniBroj)
        {
            var narudzbe = _context.Narudzbes
                .Include(x => x.Lijek)
                .Where(x => x.Lijek.UstanovaId == ustanovaId && x.RedniBroj == redniBroj && x.Status == "aktivno");
            foreach (var narudzba in narudzbe)
            {
                narudzba.Status = "isporuceno";
                narudzba.Lijek.Kolicina -= 1;
            }
            _context.SaveChanges();
            return NoContent();
        }
    }
}
