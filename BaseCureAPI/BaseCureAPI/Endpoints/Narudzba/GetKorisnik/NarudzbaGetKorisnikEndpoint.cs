using BaseCureAPI.DB;
using BaseCureAPI.Endpoints.Narudzba.Get;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.Narudzba.GetKorisnik
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

        [HttpGet("korisnik/{korisnikId}")]
        public ActionResult<List<NarudzbaGetKorisnikRes>> GetNarudzbe([FromRoute] int korisnikId)
        {
            var narudzbe = _context.Narudzbes
                .Include(x => x.Korisnik)
                .Include(x => x.Lijek)
                .Where(x => x.KorisnikId == korisnikId && x.Status == "neaktivno")
                .Select(x => new NarudzbaGetKorisnikRes
                {
                    NarudzbaId = x.NarudzbaId,
                    KorisnikId = x.KorisnikId,
                    LijekId = x.LijekId,
                    NazivLijeka = x.Lijek.NazivLijeka,
                    OpisLijeka = x.Lijek.OpisLijeka,
                    CijenaLijeka = x.Lijek.CijenaLijeka,
                    Status = x.Status
                })
                .ToList();
            return Ok(narudzbe);
        }
    }
}
