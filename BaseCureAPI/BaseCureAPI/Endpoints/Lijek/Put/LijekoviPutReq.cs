namespace BaseCureAPI.Endpoints.Lijek.Put
{
    public class LijekoviPutReq
    {
        public string? Naziv { get; set; }
        public bool? ZahtijevaRecept { get; set; }
        public byte[]? Slika { get; set; }
        public int? UstanovaId { get; set; }
        public float? Cijena { get; set; }
        public int? Kolicina { get; set; }
        public string? Opis { get; set; }
    }
}
