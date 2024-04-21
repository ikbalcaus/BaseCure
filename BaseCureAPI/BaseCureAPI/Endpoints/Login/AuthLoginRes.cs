using System.Text.Json.Serialization;
using BaseCureAPI.DB.Models;

namespace BaseCureAPI.Endpoints.Login
{
    /*
     IpAdresa = Request.HttpContext.Connection.RemoteIpAddress?.ToString(),
                Vrijednost = randomString,
                KorisnikId = logiraniKorisnik.KorisnikId,
                 Korisnickoime
                 Lozinka
                 Ime
                 Prezime
                dtmrodj
                addre
                mailaddr
                grad.naziv
                osoblje.uloga.naziv

                Korisnik = logiraniKorisnik,
                VrijemeEvidentiranja = DateTime.Now,
                Code2f = Guid.NewGuid().ToString(),
     */
    public class AuthLoginRes
    {
        public string? Vrijednost { get; set; }
        public DateTime? VrijemeEvidentiranja { get; set; }
        public string? IpAdresa { get; set; }
        public string? Code2f { get; set; }
        public int? KorisnikId { get; set; }
        [JsonIgnore]
        public Korisnici Korisnik { get; set; }
        public string? KorisnickoIme => Korisnik.KorisnickoIme;
        public string? Ime => Korisnik.Ime;
        public string? Prezime => Korisnik.Prezime;
        public DateTime? DatumRodjenja => Korisnik.DatumRodjenja;
        public string Adresa => Korisnik.Adresa;
        public string MailAdresa => Korisnik.MailAdresa;
        [JsonIgnore]
        public Gradovi? grad => Korisnik.Grad;
        public string? Grad => grad?.Naziv;
        [JsonIgnore]
        public Uloge? uloga => Korisnik?.Osoblje?.Uloga;
        public string? Uloga => uloga?.Naziv;
    }
}
