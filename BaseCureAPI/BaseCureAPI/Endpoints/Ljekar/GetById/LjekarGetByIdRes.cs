using BaseCureAPI.DB.Models;
using System.Text.Json.Serialization;

namespace BaseCureAPI.Endpoints.Ljekar.GetById
{
    public class LjekarGetByIdRes
    {
        public int LjekarId { get; set; }
        public string? Specijalizacija { get; set; }
        [JsonIgnore]
        public Korisnici Korisnik { get; set; }
        public string Ime => Korisnik.Ime;
        public string Prezime => Korisnik.Prezime;
        public string mail => Korisnik.MailAdresa;
        public string brojTelefona => Korisnik.BrojTelefona;
        [JsonIgnore]
        public UstanoveZdravstva Ustanova { get; set; }
        public string OpisUstanove => Ustanova.Opis;

    }
}
