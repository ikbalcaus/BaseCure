using System;
using System.Collections.Generic;

namespace BaseCureAPI.DB.Models
{
    public partial class Osoblje
    {
        public Osoblje()
        {
            Korisnicis = new HashSet<Korisnici>();
        }

        public int OsobljeId { get; set; }
        public string? PunoIme { get; set; }
        public int? UstanovaId { get; set; }
        public int? UlogaId { get; set; }
        public virtual Uloge? Uloga { get; set; }
        public virtual UstanoveZdravstva? Ustanova { get; set; }
        public virtual ICollection<Korisnici> Korisnicis { get; set; }
    }
}
