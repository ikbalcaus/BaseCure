namespace BaseCureAPI.Endpoints.Korisnik.Put
{
    public class KorisniciPutRes
    {
        //public int KorisnikId { get; set; }
        public string? KorisnickoIme { get; set; }
        public string? HashLozinke { get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? Adresa { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string? MailAdresa { get; set; }
        public string? Uloga { get; set; }
    }
}