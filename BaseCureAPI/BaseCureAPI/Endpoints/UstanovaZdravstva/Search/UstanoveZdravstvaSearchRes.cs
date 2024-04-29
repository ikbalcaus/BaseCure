namespace BaseCureAPI.Endpoints.UstanovaZdravstva.Search
{
    public class UstanoveZdravstvaSearchRes
    {
        public int UstanovaId {  get; set; }
        public string Naziv { get; set; }
        public string Grad { get; set; }
        public string TipUstanove { get; set; }
    }
}
