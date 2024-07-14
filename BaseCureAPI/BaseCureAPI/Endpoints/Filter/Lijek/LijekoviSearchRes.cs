namespace BaseCureAPI.Endpoints.Filter.Lijek
{
    public class LijekoviSearchRes
    {
        public int LijekId { get; set; }
        public string? Naziv { get; set; }
        public bool? ZahtijevaRecept { get; set; }
        public string? Opis { get; set; }
        public int? Kolicina { get; set; }
        public double? Cijena { get; set; }
    }
}
