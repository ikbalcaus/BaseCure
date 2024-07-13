namespace BaseCureAPI.Endpoints.Narudzba.PutKorisnik
{
    public class NarudzbePutKorisnikReq
    {
        public string? ImePrezime { get; set; }
        public string? TelefonskiBroj { get; set; }
        public int? GradId { get; set; }
        public string? Adresa { get; set; }
        public string? MailAdresa { get; set; }
    }
}
