namespace BaseCureAPI.Endpoints.Lijek.GetById
{
    public class LijekoviGetByIdRes
    {
        public int LijekId { get; set; }
        public string? Naziv { get; set; }
        public bool? ZahtijevaRecept { get; set; }
        public byte[]? Slika { get; set; }
        public int? UstanovaId { get; set; }
        public float? Cijena { get; set; }
        public int? Kolicina { get; set; }
        public string? Opis { get; set; }
    }
}
