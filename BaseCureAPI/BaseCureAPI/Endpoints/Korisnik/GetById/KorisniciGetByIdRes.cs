namespace BaseCureAPI.Endpoints.Korisnik.GetById
{
    public class KorisniciGetByIdRes
    {
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? BrojTelefona { get; set; }
        public string? Adresa { get; set; }
        public string? MailAdresa { get; set; }
        public string? Grad { get; set; }
    }
}