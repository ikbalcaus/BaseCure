using BaseCureAPI.DB;
using BaseCureAPI.DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Endpoints.Uputnica.Post
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
        public ActionResult CreateUputnicu([FromBody] UputnicePostReq request)
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
            _context.SaveChanges();
            return Ok(new UputnicePostRes
            {
                MedicalRecordId = medicalRecord.PacijentId
            });
        }
    }

    public class UputnicePostReq
    {
        public decimal? Tezina { get; set; }
        public decimal? Visina { get; set; }
        public string? KrvnaGrupa { get; set; }
        public int? PritisakSistolicki { get; set; }
        public int? PritisakDistolicki { get; set; }
        public int? Pulz { get; set; }
        public string? Alergije { get; set; }
        public string? TrenutneBolesti { get; set; }
        public string? RanijeBolesti { get; set; }
        public string? Lijekovi { get; set; }
        public string? PorodicnaAnamneza { get; set; }
        public string? NavikePonasanja { get; set; }
    }

    public class UputnicePostRes
    {
        public int MedicalRecordId { get; set; }
    }
}
