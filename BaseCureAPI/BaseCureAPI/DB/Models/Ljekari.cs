using System;
using System.Collections.Generic;

namespace BaseCureAPI.DB.Models
{
    public partial class Ljekari
    {
        public Ljekari()
        {
            Pregledis = new HashSet<Pregledi>();
            Receptis = new HashSet<Recepti>();
            Terminis = new HashSet<Termini>();
        }

        public int LjekarId { get; set; }
        public string? Specijalizacija { get; set; }
        public int? UstanovaId { get; set; }
        public int? KorisnikId { get; set; }

        public virtual Korisnici? Korisnik { get; set; }
        public virtual UstanoveZdravstva? Ustanova { get; set; }
        public virtual ICollection<Pregledi> Pregledis { get; set; }
        public virtual ICollection<Recepti> Receptis { get; set; }
        public virtual ICollection<Termini> Terminis { get; set; }
    }
}
