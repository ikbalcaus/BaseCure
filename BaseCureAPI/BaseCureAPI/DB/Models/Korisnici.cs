using System;
using System.Collections.Generic;

namespace BaseCureAPI.DB.Models
{
    public partial class Korisnici
    {
        public Korisnici()
        {
            AuthTokens = new HashSet<AuthToken>();
            Ljekaris = new HashSet<Ljekari>();
            Narudzbes = new HashSet<Narudzbe>();
            Pacijentis = new HashSet<Pacijenti>();
        }

        public int KorisnikId { get; set; }
        public string? KorisnickoIme { get; set; }
        public string? HashLozinke { get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? Adresa { get; set; }
        public DateTime? DatumRodjenja { get; set; }
        public string? MailAdresa { get; set; }
        public string? Code2fa { get; set; }
        public int? GradId { get; set; }
        public int? OsobljeId { get; set; }

        public virtual Gradovi? Grad { get; set; }
        public virtual Osoblje? Osoblje { get; set; }
        public virtual ICollection<AuthToken> AuthTokens { get; set; }
        public virtual ICollection<Ljekari> Ljekaris { get; set; }
        public virtual ICollection<Narudzbe> Narudzbes { get; set; }
        public virtual ICollection<Pacijenti> Pacijentis { get; set; }
    }
}
