using BaseCureAPI.DB;
using BaseCureAPI.DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Endpoints.Uputnice.Post
{
    [Route("uputnice")]
    [ApiController]
    public class UputniceController : ControllerBase
    {
        private readonly BasecureContext _context;

        public UputniceController(BasecureContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<UputnicePostRes>> CreateUputnicu([FromBody] UputnicePostReq request)
        {
            var medicalRecord = new Pacijenti
            {
                Tezina = request.Tezina,
                Visina = request.Visina,
                KrvnaGrupa = request.KrvnaGrupa,
                PritisakSistolicki = request.PritisakSistolicki,
                PritisakDistolicki = request.PritisakDistolicki,
                Pulz = request.Pulz,
                Alergije = request.Alergije,
                TrenutneBolesti = request.TrenutneBolesti,
                RanijeBolesti = request.RanijeBolesti,
                Lijekovi = request.Lijekovi,
                PorodicnaAnamneza = request.PorodicnaAnamneza,
                NavikePonasanja = request.NavikePonasanja
            };
            _context.Pacijentis.Add(medicalRecord);
            await _context.SaveChangesAsync();
            return new UputnicePostRes
            {
                MedicalRecordId = medicalRecord.PacijentId
            };
        }
    }
}
