using System.ComponentModel.DataAnnotations;

namespace BaseCureAPI.Data.Models
{
    public class Korisnik
    {
        [Key]
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string MailAdresa { get; set; }
        public string HashLozinke { get; set; }
        public string Adresa { get; set; }
        public string Uloga { get; set; }
        public string KontaktBroj { get; set; }
        public DateTime DatumRodjenja { get; set; }
    }
}
