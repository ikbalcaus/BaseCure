using System.Text.Json.Serialization;
using BaseCureAPI.DB;
using BaseCureAPI.DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Endpoints.Ljekar.GetById
{
    [Route("ljekari")]
    [ApiController]
    public class LjekariController : ControllerBase
    {
        private readonly BasecureContext _context;

        public LjekariController(BasecureContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult Get([FromRoute] int id)
        {
            var ljekar = _context.Ljekaris.Where(x => x.LjekarId == id)
                .Select(x => new LjekarGetByIdRes()
                {
                    LjekarId = x.LjekarId,
                    Specijalizacija = x.Specijalizacija,
                    Opis = x.Opis,
                    Korisnik = x.Korisnik,
                    UstanovaZdravstva = x.Ustanova,
                    grad = x.Korisnik.Grad
                }).FirstOrDefault();

            return Ok(ljekar);
        }
    }

    public class LjekarGetByIdRes
    {
        public int? LjekarId { get; set; }
        public string? Specijalizacija { get; set; }
        public string? Opis { get; set; }
        [JsonIgnore]
        public Korisnici? Korisnik { get; set; }
        public int? KorisnikId => Korisnik?.KorisnikId;
        public string? Ime => Korisnik?.Ime;
        public string? Prezime => Korisnik?.Prezime;
        public string? MailAdresa => Korisnik?.MailAdresa;
        public string? KontaktBroj => Korisnik?.BrojTelefona;
        public string? Adresa => Korisnik?.Adresa;
        [JsonIgnore]
        public Gradovi? grad { get; set; }
        public string? Grad => grad?.Naziv;
        [JsonIgnore]
        public UstanoveZdravstva? UstanovaZdravstva { get; set; }
        public int? ustanovaId => UstanovaZdravstva?.UstanovaId;
    }
}
