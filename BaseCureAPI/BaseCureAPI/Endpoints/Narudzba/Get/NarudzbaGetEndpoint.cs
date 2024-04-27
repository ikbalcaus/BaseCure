using BaseCureAPI.DB;
using BaseCureAPI.DB.Models;
using BaseCureAPI.Endpoints.Narudzba.Get;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.Narudzba.Get
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

        [HttpGet("{korisnikId}")]
        public ActionResult<List<NarudzbaGetRes>> GetNarudzbe([FromRoute] int korisnikId)
        {
            var narudzbe = _context.Narudzbes
                .Where(x => x.KorisnikId == korisnikId)
                .Include(x => x.Korisnik)
                .Include(x => x.Lijek)
                .Select(x => new NarudzbaGetRes
                {
                    NarudzbaId = x.NarudzbaId,
                    KorisnikId = x.KorisnikId,
                    LijekId = x.LijekId,
                    NazivLijeka = x.Lijek.NazivLijeka,
                    OpisLijeka = x.Lijek.OpisLijeka,
                    CijenaLijeka = x.Lijek.CijenaLijeka,
                    Odobreno = x.Odobreno
                }) 
                .ToList(); 
            return Ok(narudzbe);
        }
    }
}
