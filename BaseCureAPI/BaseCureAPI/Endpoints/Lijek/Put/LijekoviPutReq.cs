﻿namespace BaseCureAPI.Endpoints.Lijek.Put
{
    public class LijekoviPutReq
    {
        public string? NazivLijeka { get; set; }
        public bool? ZahtijevaRecept { get; set; }
        public byte[]? SlikaLijeka { get; set; }
        public int? UstanovaId { get; set; }
        public string? OpisLijeka { get; set; }
    }
}
