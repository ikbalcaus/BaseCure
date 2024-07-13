namespace BaseCureAPI.Endpoints.Karton.Post
{
    public class KartoniPostReq
    {
        public int ID { get; set; }
        public string ImePacijenta { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public string Sadrzaj { get; set; }
    }
}
