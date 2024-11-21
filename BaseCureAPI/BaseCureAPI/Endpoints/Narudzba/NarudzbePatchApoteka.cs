using BaseCureAPI.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.Narudzba.PatchApoteka
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

        [HttpPatch("apoteka/{ustanovaId}")]
        public ActionResult UpdateNarudzba([FromRoute] int ustanovaId, [FromQuery] int redniBroj)
        {
            var isSveIsporuceno = true;
            var narudzbe = _context.Narudzbes
                .Include(x => x.Lijek)
                .Where(x => x.Lijek.UstanovaId == ustanovaId && x.RedniBroj == redniBroj && x.Status == "aktivno");

            foreach (var narudzba in narudzbe)
            {
                if (narudzba.Lijek.Kolicina > 0)
                {
                    narudzba.Status = "isporuceno";
                    narudzba.Lijek.Kolicina -= 1;
                }
                else isSveIsporuceno = false;
            }
            _context.SaveChanges();
            if (isSveIsporuceno) return NoContent();
            else return BadRequest("Nema zaliha lijeka");
        }
    }
}
