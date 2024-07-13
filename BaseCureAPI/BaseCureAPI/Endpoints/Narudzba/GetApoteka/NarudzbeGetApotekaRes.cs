using BaseCureAPI.DB.Models;

namespace BaseCureAPI.Endpoints.Narudzba.GetApoteka
{
    public class NarudzbeGetApotekaRes
    {
        public int? KorisnikId { get; set; }
        public string? ImePrezime { get; set; }
        public string? Status { get; set; }
        public int? RedniBroj { get; set; }
        public int? BrojLijekova {  get; set; }
    }
}
