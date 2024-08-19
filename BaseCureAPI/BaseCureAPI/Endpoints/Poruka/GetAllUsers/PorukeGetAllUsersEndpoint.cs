using BaseCureAPI.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.Poruka.GetAllUsers
{
    [Route("poruke")]
    [ApiController]
    public class PorukeController : ControllerBase
    {
        private readonly BasecureContext _context;

        public PorukeController(BasecureContext context)
        {
            _context = context;
        }

        [HttpGet("{korisnikId}")]
        public ActionResult GetAllUsers([FromRoute] int korisnikId)
        {
            var poruke = _context.Porukes
                .Where(x => x.PrimaocId == korisnikId)
                .Include(x => x.Posiljaoc)
                .GroupBy(x => x.PosiljaocId)
                .Select(g => new
                {
                    LastMessage = g.OrderByDescending(x => x.DatumVrijeme).FirstOrDefault(),
                    ReadMessages = g.Count(x => x.Procitana),
                    UnreadMessages = g.Count(x => !x.Procitana)
                })
                .AsEnumerable()
                .Select(p => new
                {
                    p.LastMessage?.PosiljaocId,
                    ImePrezime = p.LastMessage?.Posiljaoc.Ime + " " + p.LastMessage?.Posiljaoc.Prezime,
                    p.LastMessage?.Poruka,
                    ProcitanePoruke = p.ReadMessages,
                    NeprocitanePoruke = p.UnreadMessages,
                    DatumVrijeme = p.LastMessage?.DatumVrijeme,
                })
                .OrderByDescending(x => x.DatumVrijeme)
                .ToList();

            return Ok(poruke);
        }
    }
}
