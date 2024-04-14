namespace BaseCureAPI.Endpoints.Lijek.GetForUstanova
{
    public class LijekoviGetByUstanovaRes
    {
        public int LijekId { get; set; }
        public string NazivLijeka { get; set; }
        public bool? ZahtijevaRecept { get; set; }
        public string OpisLijeka { get; set; }
    }
}
