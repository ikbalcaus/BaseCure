using System;
using System.Collections.Generic;

namespace BaseCureAPI.DB.Models
{
    public partial class Korisnici
    {
        public Korisnici()
        {
            Ljekaris = new HashSet<Ljekari>();
            Osobljes = new HashSet<Osoblje>();
            Pacijentis = new HashSet<Pacijenti>();
        }

        public int KorisnikId { get; set; }
        public string? KorisnickoIme { get; set; }
        public string? HashLozinke { get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? Adresa { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string? MailAdresa { get; set; }
        public string? Uloga { get; set; }

        public virtual ICollection<Ljekari> Ljekaris { get; set; }
        public virtual ICollection<Osoblje> Osobljes { get; set; }
        public virtual ICollection<Pacijenti> Pacijentis { get; set; }
        public virtual ICollection<AuthToken> AuthTokens { get; set; }
    }
}
