namespace BaseCureAPI.Endpoints.Lijek.Post
{
    public class LijekoviPostReq
    {
        public int ID { get; set; }
        public string? Naziv { get; set; }
        public bool? ZahtijevaRecept { get; set; }
        public int? UstanovaId { get; set; }
        public float? Cijena { get; set; }
        public int? Kolicina {  get; set; }
        public string? Opis { get; set; }
    }
}
