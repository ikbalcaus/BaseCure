using System;
using System.Collections.Generic;

namespace BaseCureAPI.DB.Models
{
    public partial class Pacijenti
    {
        public Pacijenti()
        {
            Placanjes = new HashSet<Placanje>();
            Terminis = new HashSet<Termini>();
            ZdravstveniKartonis = new HashSet<ZdravstveniKartoni>();
        }

        public int PacijentId { get; set; }
        public int? KorisnikId { get; set; }

        public virtual Korisnici? Korisnik { get; set; }
        public virtual ICollection<Placanje> Placanjes { get; set; }
        public virtual ICollection<Termini> Terminis { get; set; }
        public virtual ICollection<ZdravstveniKartoni> ZdravstveniKartonis { get; set; }
    }
}
