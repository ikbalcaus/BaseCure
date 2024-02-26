using BaseCureAPI.DB;
using BaseCureAPI.DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.Korisnik.GetById
{
    [Route("korisnici")]
    [ApiController]
    public class KorisniciGetByIdEndpoint : ControllerBase
    {
        private readonly BasecureContext _context;

        public KorisniciGetByIdEndpoint(BasecureContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult GetKorisnik([FromRoute] KorisniciGetByIdReq req)
        {
            var korisnikEntity = _context.Korisnicis
                .OrderByDescending(x => x.KorisnikId)
                .FirstOrDefault(x => x.KorisnikId == req.id);

            if (korisnikEntity == null)
            {
                return NotFound();
            }

            var korisnik = new KorisniciGetByIdRes
            {
                KorisnickoIme = korisnikEntity.KorisnickoIme,
                HashLozinke = korisnikEntity.HashLozinke,
                Ime = korisnikEntity.Ime,
                Prezime = korisnikEntity.Prezime
                //Adresa = korisnikEntity.Adresa,
                //DatumRodjenja = (DateTime)korisnikEntity.DatumRodjenja,
                //MailAdresa = korisnikEntity.MailAdresa,
                //Uloga = korisnikEntity.Uloga,
            };

            if (korisnik == null)
            {
                return NotFound();
            }

            return Ok(korisnik);
        }
    }
}