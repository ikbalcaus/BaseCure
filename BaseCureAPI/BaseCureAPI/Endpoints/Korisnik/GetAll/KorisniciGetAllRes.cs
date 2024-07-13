namespace BaseCureAPI.Endpoints.Korisnik.GetAll
{
    public class KorisniciGetAllRes
    {
        public int KorisnikId { get; set; }
        public string? HashLozinke { get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? Adresa { get; set; }
        public DateTime? DatumRodjenja { get; set; }
        public string? MailAdresa { get; set; }
        public string? Code2fa { get; set; }
    }
}
