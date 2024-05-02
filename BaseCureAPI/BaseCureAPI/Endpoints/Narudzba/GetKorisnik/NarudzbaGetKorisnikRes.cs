namespace BaseCureAPI.Endpoints.Narudzba.GetKorisnik
{
    public class NarudzbaGetKorisnikRes
    {
        public int NarudzbaId {  get; set; }
        public int? KorisnikId { get; set; }
        public int? LijekId { get; set; }
        public string? NazivLijeka { get; set; }
        public string? OpisLijeka { get; set; }
        public double? CijenaLijeka { get; set; }
        public string? Status { get; set; }
    }
}
