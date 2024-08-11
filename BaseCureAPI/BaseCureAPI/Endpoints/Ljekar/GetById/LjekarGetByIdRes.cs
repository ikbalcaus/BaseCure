using BaseCureAPI.DB.Models;
using System.Text.Json.Serialization;

namespace BaseCureAPI.Endpoints.Ljekar.GetById
{
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
