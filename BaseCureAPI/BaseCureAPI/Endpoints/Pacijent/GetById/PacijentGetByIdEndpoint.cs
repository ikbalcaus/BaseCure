using BaseCureAPI.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Endpoints.Pacijent.GetById
{
    [Route("/pacijenti")]
    [ApiController]
    public class PacijentController : ControllerBase
    {
        private readonly BasecureContext _context;

        public PacijentController(BasecureContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var pacijent = _context.Pacijentis
                .Where(x => x.PacijentId == id)
                .Select(x => new PacijentGetByIdRes
                {
                    Tezina = x.Tezina,
                    Visina = x.Visina,
                    KrvnaGrupa = x.KrvnaGrupa,
                    PritisakSistolicki = x.PritisakSistolicki,
                    PritisakDistolicki = x.PritisakDistolicki,
                    Pulz = x.Pulz,
                    Alergije = x.Alergije,
                    TrenutneBolesti = x.TrenutneBolesti,
                    RanijeBolesti = x.RanijeBolesti,
                    Lijekovi = x.Lijekovi,
                    PorodicnaAnamneza = x.PorodicnaAnamneza,
                    NavikePonasanja = x.NavikePonasanja
                }).ToList();
            return Ok(pacijent);
        }
    }
}
