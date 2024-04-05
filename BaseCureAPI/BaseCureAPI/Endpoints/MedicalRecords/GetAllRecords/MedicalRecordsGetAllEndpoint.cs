using BaseCureAPI.DB;
using BaseCureAPI.DB.Models;
using BaseCureAPI.Endpoints.Korisnik.GetAll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.MedicalRecords.GetAllRecords
{
    [Route("medicalRecords")]
    [ApiController]
    public class MedicalRecordsGetAllEndpoint : ControllerBase
    {
        private readonly BasecureContext _context;

        public MedicalRecordsGetAllEndpoint(BasecureContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<RecordsGetAllResList> Get()
        {
            var kartoni = _context.ZdravstveniKartonis.OrderByDescending(x => x.KartonId)
                .Include(x => x.Pacijent)
                .ThenInclude(p => p.Korisnik)
                .Select(x => new MedicalRecordsGetAllRes()
                {
                    KartonId = x.KartonId,
                    DatumIzdavanja = x.DatumIzdavanja,
                    PacijentId = x.PacijentId,
                    Pacijent = x.Pacijent != null ? new Pacijenti
                    {
                        PacijentId = (int)x.PacijentId,
                        KorisnikId = x.Pacijent.KorisnikId,
                    } : null,
                    Korisnik = x.Pacijent != null && x.Pacijent.Korisnik != null ? new Korisnici
                    {
                        KorisnikId = x.Pacijent.Korisnik.KorisnikId,
                        Ime = x.Pacijent.Korisnik.Ime
                    } : null

                }).ToList();

            return new RecordsGetAllResList
            {
                Kartoni = kartoni
            };
        }
    }
}
