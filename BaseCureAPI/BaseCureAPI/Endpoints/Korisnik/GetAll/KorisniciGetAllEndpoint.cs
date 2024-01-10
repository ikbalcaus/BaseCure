using BaseCureAPI.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.Korisnik.GetAll
{
    [Route("korisnici")]
    [ApiController]
    public class KorisniciGetAllEndpoint : ControllerBase
    {
        private readonly BasecureContext _context;

<<<<<<< HEAD
        public KorisniciGetAllEndpoint(BasecureContext context)
        {
=======
        public KorisniciGetAllEndpoint(BasecureContext context) { 
>>>>>>> parent of e1da335 (Revert "Segmented Korisnici API routes into individual files")
            _context = context;
        }

        [HttpGet]
        public ActionResult<KorisniciGetAllResponse> Get()
        {
            var korisnik = _context.Korisnicis.OrderByDescending(x => x.KorisnikId)
                .Select(x => new KorisniciGetAllRes()
                {
                    KorisnikId = x.KorisnikId,
                    KorisnickoIme = x.KorisnickoIme,
                    HashLozinke = x.HashLozinke,
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    //Adresa = x.Adresa,
                    //DatumRodjenja = (DateTime)x.DatumRodjenja,
                    //MailAdresa = x.MailAdresa,
                    //Uloga = x.Uloga,
                }).ToList();

            return new KorisniciGetAllResponse
            {
                Korisnici = korisnik
            };
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> parent of e1da335 (Revert "Segmented Korisnici API routes into individual files")
