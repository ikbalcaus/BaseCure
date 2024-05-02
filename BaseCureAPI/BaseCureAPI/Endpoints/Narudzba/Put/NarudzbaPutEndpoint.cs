using BaseCureAPI.DB;
using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Endpoints.Narudzba.Put
{
    [Route("narudzba")]
    [ApiController]
    public class NaruzbeController : ControllerBase
    {
        private readonly BasecureContext _context;

        public NaruzbeController(BasecureContext context)
        {
            _context = context;
        }

        [HttpPut("{korisnikId}")]
        public ActionResult UpdateNarudzba([FromRoute] int korisnikId)
        {
            var narudzbe = _context.Narudzbes.Where(x => x.KorisnikId == korisnikId);
            foreach (var narudzba in narudzbe)
            {
                narudzba.Odobreno = true;
            }
            _context.SaveChanges();
            return NoContent();
        }
    }
}
