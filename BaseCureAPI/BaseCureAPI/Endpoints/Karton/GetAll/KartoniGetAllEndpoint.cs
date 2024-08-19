using BaseCureAPI.DB;
using BaseCureAPI.DB.Models;
using BaseCureAPI.Endpoints.Karton.GetAll;
using BaseCureAPI.Endpoints.Korisnik.GetAll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.Karton.GetAll
{
    [Route("kartoni")]
    [ApiController]
    public class KartoniController : ControllerBase
    {
        private readonly BasecureContext _context;

        public KartoniController(BasecureContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var kartoni = _context.ZdravstveniKartonis.OrderByDescending(x => x.KartonId)
                .Include(x => x.Pacijent)
                    .ThenInclude(x => x.Korisnik)
                .Select(x => new KartoniGetAllRes()
                {
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

            return Ok(kartoni);
        }
    }
}
