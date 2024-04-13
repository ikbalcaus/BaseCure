using BaseCureAPI.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.Uputnice.GetAll
{
    [Route("uputnice")]
    [ApiController]
    public class UputniceGellAllEndpoint : ControllerBase
    {
        private readonly BasecureContext _context;

        public UputniceGellAllEndpoint(BasecureContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UputniceGetAllRes>>> GetPatientsWithMedicalRecordsAndTherapies()
        {
            var patients = await _context.ZdravstveniKartonis
                .Include(k => k.Pacijent)
                .Include(k => k.Terapijes)
                .Select(k => new UputniceGetAllRes
                {
                    PatientId = k.Pacijent.PacijentId,
                    PatientName = $"{k.Pacijent.Korisnik.Ime} {k.Pacijent.Korisnik.Prezime}",
                    MedicalRecords = k.Sadrzaj,
                    Therapies = k.Terapijes.Select(t => new TerapijaDto
                    {
                        TherapyId = t.TerapijaId,
                        TherapyName = t.NazivTerapije,
                        StartDate = t.PocetakTerapije,
                        EndDate = t.KrajTerapije
                    }).ToList()
                })
                .ToListAsync();

            return Ok(patients);
        }
    }
}

