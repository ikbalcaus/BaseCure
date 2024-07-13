﻿using BaseCureAPI.Endpoints.Korisnik;

namespace BaseCureAPI.Endpoints.UstanovaZdravstva.GetByParams
{
    public class UstanoveZdravstvaGetByParamsRes
    {
        public int UstanovaId { get; set; }
        public string? Naziv { get; set; }
        public string? Opis {  get; set; }
        public string? Adresa { get; set; }
        public string? BrojTelefona { get; set; }
        public string? MailAdresa { get; set; }
        public string? Grad { get; set; }
        public string? TipUstanove { get; set; }
        public float? CijenaDostave {  get; set; }
        public byte[] ImageData { get; set; }
    }
}
