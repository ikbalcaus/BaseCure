namespace BaseCureAPI.Endpoints.Narudzba.Get
{
    public class NarudzbaGetRes
    {
        public int NarudzbaId {  get; set; }
        public int? KorisnikId { get; set; }
        public int? LijekId { get; set; }
        public string? NazivLijeka { get; set; }
        public string? OpisLijeka { get; set; }
        public double? CijenaLijeka { get; set; }
        public bool? Odobreno {  get; set; }
    }
}
