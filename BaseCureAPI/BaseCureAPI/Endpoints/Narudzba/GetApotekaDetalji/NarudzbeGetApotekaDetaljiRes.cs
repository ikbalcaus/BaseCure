using BaseCureAPI.DB.Models;

namespace BaseCureAPI.Endpoints.Narudzba.GetApotekaDetalji
{
    public class NarudzbeGetApotekaDetaljiRes
    {
        public int? NarudzbaId { get; set; }
        public int? KorisnikId { get; set; }
        public string? ImePrezime { get; set; }
        public string? BrojTelefona { get; set; }
        public string? Grad { get; set; }
        public string? Adresa { get; set; }
        public string? MailAdresa { get; set; }
        public int? LijekId { get; set; }
        public string? Naziv { get; set; }
        public string? Opis { get; set; }
        public double? Cijena { get; set; }
        public double? CijenaDostave { get; set; }
        public string? Status { get; set; }
    }
}
