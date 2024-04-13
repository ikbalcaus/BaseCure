﻿namespace BaseCureAPI.Endpoints.Lijek.Post
{
    public class LijekoviPostReq
    {
        public int ID { get; set; }
        public string? NazivLijeka { get; set; }
        public bool? ZahtijevaRecept { get; set; }
        public byte[]? SlikaLijeka { get; set; }
        public int? UstanovaId { get; set; }
        public float? CijenaLijeka { get; set; }
        public int? Kolicina {  get; set; }
        public string? OpisLijeka { get; set; }
    }
}
