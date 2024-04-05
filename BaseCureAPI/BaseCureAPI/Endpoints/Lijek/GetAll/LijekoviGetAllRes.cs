namespace BaseCureAPI.Endpoints.Lijek.GetAll
{
    public class LijekoviGetAllRes
    {
        public int LijekId { get; set; }
        public string? NazivLijeka { get; set; }
        public bool? ZahtijevaRecept { get; set; }
        public byte[] SlikaLijeka { get; set; }
        public int? UstanovaId { get; set; }
        public string? OpisLijeka { get; set; }
    }

    public class LijekoviGetAllResList
    {
        public List<LijekoviGetAllRes> Lijekovi { get; set; }
    }
}
