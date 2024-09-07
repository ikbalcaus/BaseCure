namespace BaseCureAPI.Endpoints.Korisnik.Put
{
    public class KorisniciPutReq
    {
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? Grad { get; set; }
        public string? Adresa { get; set; }
        public string? MailAdresa { get; set; }
        public string? BrojTelefona { get; set; }
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
        public string? RepeatNewPassword { get; set; }
    }
}
