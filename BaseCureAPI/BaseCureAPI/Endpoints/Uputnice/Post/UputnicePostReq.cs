namespace BaseCureAPI.Endpoints.Uputnice.Post
{
    public class UputnicePostReq
    {
        public decimal? Tezina { get; set; }
        public decimal? Visina { get; set; }
        public string? KrvnaGrupa { get; set; }
        public int? PritisakSistolicki { get; set; }
        public int? PritisakDistolicki { get; set; }
        public int? Pulz { get; set; }
        public string? Alergije { get; set; }
        public string? TrenutneBolesti { get; set; }
        public string? RanijeBolesti { get; set; }
        public string? Lijekovi { get; set; }
        public string? PorodicnaAnamneza { get; set; }
        public string? NavikePonasanja { get; set; }
    }
}
