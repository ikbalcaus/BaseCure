namespace BaseCureAPI.Endpoints.Korisnik.Put
{
    public class KorisniciPutReq
    {
        public string? HashLozinke { get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? Adresa { get; set; }
        public DateTime? DatumRodjenja { get; set; }
        public string? MailAdresa { get; set; }
        public string? Code2fa { get; set; }
        public string? BrojTelefona { get; set; }
    }
}
