namespace BaseCureAPI.Endpoints.UstanovaZdravstva.Post
{
    public class UstanoveZdravstvaPostRes
    {
        public int? UstanovaId { get; set; } 
        public string? Naziv { get; set; }
        public string? Adresa { get; set; }
        public string? BrojTelefona { get; set; }
        public string? MailAdresa { get; set; }
        public string? Grad { get;set; }
    }
}
