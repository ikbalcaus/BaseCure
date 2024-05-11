namespace BaseCureAPI.Endpoints.Narudzba.PutKorisnik
{
    public class NarudzbaPutKorisnikReq
    {
        public string? ImePrezime { get; set; }
        public string? TelefonskiBroj { get; set; }
        public int? GradId { get; set; }
        public string? Adresa { get; set; }
        public string? MailAdresa { get; set; }
    }
}
