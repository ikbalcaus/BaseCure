using BaseCureAPI.DB.Models;

namespace BaseCureAPI.Endpoints.UstanovaZdravstva.Put
{
    public class UstanoveZdravstvaPutReq
    {
        public string? Naziv { get; set; }
        public string? Adresa { get; set; }
        public string? BrojTelefona { get; set; }
        public string? MailAdresa { get; set; }
        public string? Opis { get; set; }
        public float? CijenaDostave { get; set; }
        //public byte[] Slika { get; set; }
        public string? Grad { get; set; }
    }
}
