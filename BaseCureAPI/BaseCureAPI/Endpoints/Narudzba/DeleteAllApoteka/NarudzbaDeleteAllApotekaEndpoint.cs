using BaseCureAPI.DB;
using BaseCureAPI.DB.Models;
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

        [HttpDelete("apoteka/{ustanovaId}")]
        public ActionResult DeleteAllNarudzba([FromRoute] int ustanovaId)
        {
            var narudzbe = _context.Narudzbes
                .Include(x => x.Lijek)
                .Where(x => x.Lijek.UstanovaId == ustanovaId);

            foreach (var narudzba in narudzbe)
            {
                _context.Narudzbes.Remove(narudzba);
            }
            _context.SaveChanges();

            return NoContent();
        }
    }
}
