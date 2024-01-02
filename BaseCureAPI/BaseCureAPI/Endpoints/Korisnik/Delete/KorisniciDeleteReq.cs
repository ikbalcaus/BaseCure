namespace BaseCureAPI.Endpoints.Korisnik.Delete
{
    public class KorisniciDeleteReq
    {
        public int ID { get; set; }
        public string KorisnickoIme { get; set; }
        public string HashLozinke { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
    }
}