namespace BaseCureAPI.Endpoints.UstanovaZdravstva.Put
{
    public class UstanoveZdravstvaPutReq
    {
        public int UstanovaId { get; set; }
        public string Naziv { get; set; }
        public string Grad { get; set; }
    }
}
