namespace BaseCureAPI.Endpoints.Korisnik.GetById
{
    public class KorisniciGetByIdReq
    {
        public int ID { get; set; }
        public string KorisnickoIme { get; set; }
        public string HashLozinke { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
    }
}
