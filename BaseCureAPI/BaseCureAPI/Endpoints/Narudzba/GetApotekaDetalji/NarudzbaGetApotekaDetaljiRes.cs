using BaseCureAPI.DB.Models;

namespace BaseCureAPI.Endpoints.Narudzba.GetApotekaDetalji
{
    public class NarudzbaGetApotekaDetaljiRes
    {
        public int? NarudzbaId { get; set; }
        public int? KorisnikId { get; set; }
        public string? ImePrezime { get; set; }
        public string? TelefonskiBroj { get; set; }
        public string? Grad { get; set; }
        public string? Adresa { get; set; }
        public string? MailAdresa { get; set; }
        public int? LijekId { get; set; }
        public string? NazivLijeka { get; set; }
        public string? OpisLijeka { get; set; }
        public double? CijenaLijeka { get; set; }
        public double? CijenaDostave { get; set; }
        public string? Status { get; set; }
    }
}
