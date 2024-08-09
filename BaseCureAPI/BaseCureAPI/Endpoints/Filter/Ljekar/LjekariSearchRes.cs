using BaseCureAPI.DB.Models;
using System.Text.Json.Serialization;

namespace BaseCureAPI.Endpoints.Filter.Ljekar
{
    public class LjekariSearchRes
    {
        public int? LjekarId { get; set; }
        public string? Specijalizacija { get; set; }
        [JsonIgnore]
        public Korisnici Korisnik { get; set; }
        public string ImePrezime => $"{Korisnik?.Ime} {Korisnik?.Prezime}";
    }
}
