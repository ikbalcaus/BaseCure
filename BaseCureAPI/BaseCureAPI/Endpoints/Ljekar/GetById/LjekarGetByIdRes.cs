using BaseCureAPI.DB.Models;
using System.Text.Json.Serialization;

namespace BaseCureAPI.Endpoints.Ljekar.GetById
{
    public class LjekarGetByIdRes
    {
        public int? LjekarId { get; set; }
        public string? Specijalizacija { get; set; }
        [JsonIgnore]
        public Korisnici? Korisnik { get; set; }
        public string? Ime => Korisnik?.Ime;
        public string? Prezime => Korisnik?.Prezime;
        public string? MailAdresa => Korisnik?.MailAdresa;
        public string? Adresa => Korisnik?.Adresa;
        [JsonIgnore]
        public Gradovi? grad => Korisnik?.Grad;
        public string? Grad => grad?.Naziv;
    }
}
