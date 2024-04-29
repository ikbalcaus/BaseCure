﻿using BaseCureAPI.Endpoints.Korisnik;

namespace BaseCureAPI.Endpoints.UstanovaZdravstva.GetByParams
{
    public class UstanoveZdravstvaGetByParamsRes
    {
        public int UstanovaId { get; set; }
        public string? Naziv { get; set; }
        public string? Adresa { get; set; }
        public string? KontaktBroj { get; set; }
        public string? Email { get; set; }
        public string? Grad { get; set; }
        public string? TipUstanove { get; set; }
    }
}
