using BaseCureAPI.DB.Models;

namespace BaseCureAPI.Endpoints.Narudzba.GetApotekaDetalji
{
    public class NarudzbaGetApotekaDetaljiRes
    {
        public int? KorisnikId { get; set; }
        public string? ImePrezime { get; set; }
        public string? Status { get; set; }
        public int? BrojLijekova {  get; set; }
    }
}
