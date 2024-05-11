using BaseCureAPI.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.Narudzba.DeleteAllApoteka
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

        [HttpDelete("apoteka/{ustanovaId}/korisnik/{redniBroj}")]
        public ActionResult DeleteAllNarudzba([FromRoute] int ustanovaId, [FromRoute] int redniBroj)
        {
            var narudzbe = _context.Narudzbes
                .Include(x => x.Lijek)
                .Where(x => x.Lijek.UstanovaId == ustanovaId && x.RedniBroj == redniBroj && x.Status == "isporuceno");

            foreach (var narudzba in narudzbe)
            {
                _context.Narudzbes.Remove(narudzba);
            }
            _context.SaveChanges();

            return NoContent();
        }
    }
}
