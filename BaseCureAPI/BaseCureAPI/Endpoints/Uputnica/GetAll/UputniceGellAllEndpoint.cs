using BaseCureAPI.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.Uputnica.GetAll
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

        [HttpGet]
        public ActionResult GetPatientsWithMedicalRecordsAndTherapies()
        {
            var patients = _context.ZdravstveniKartonis
                .Include(x => x.Pacijent)
                .Include(x => x.Terapijes)
                .Select(x => new UputniceGetAllRes
                {
                    PatientId = x.Pacijent.PacijentId,
                    PatientName = $"{x.Pacijent.Korisnik.Ime} {x.Pacijent.Korisnik.Prezime}",
                    MedicalRecords = x.Sadrzaj,
                    Therapies = x.Terapijes.Select(t => new TerapijaDto
                    {
                        TherapyId = t.TerapijaId,
                        TherapyName = t.NazivTerapije,
                        StartDate = t.PocetakTerapije,
                        EndDate = t.KrajTerapije
                    }).ToList()
                })
                .ToList();

            return Ok(patients);
        }
    }
}

