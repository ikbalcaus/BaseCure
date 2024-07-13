namespace BaseCureAPI.Endpoints.MedicinskiKarton.Post
{
    public class MedicalRecordsPostReq
    {
        public int ID { get; set; }
        public string ImePacijenta { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public string Sadrzaj { get; set; }
    }
}
