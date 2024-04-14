namespace BaseCureAPI.Endpoints.UstanovaZdravstva.Post
{
    public class UstanoveZdravstvaPostRes
    {
        public int? UstanovaId { get; set; } 
        public string? Naziv { get; set; }
        public string? Adresa { get; set; }
        public string? KontaktBroj { get; set; }
        public string? Email { get; set; }
        public string? Grad { get;set; }
    }
}
