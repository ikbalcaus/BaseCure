using BaseCureAPI.DB.Models;
using System.Text.Json.Serialization;

namespace BaseCureAPI.Endpoints.Ljekar.GetById
{
    public class LjekarGetByIdRes
    {
        public int? LjekarId { get; set; }
        public string? Specijalizacija { get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? MailAdresa { get; set; }
        public string? Adresa { get; set; }
        public string? Grad { get; set; }
    }
}
