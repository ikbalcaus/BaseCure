using System;
using System.Collections.Generic;

namespace BaseCureAPI.DB.Models
{
    public partial class Terapije
    {
        public Terapije()
        {
            Receptis = new HashSet<Recepti>();
        }

        public int TerapijaId { get; set; }
        public string? NazivTerapije { get; set; }
        public DateTime? PocetakTerapije { get; set; }
        public DateTime? KrajTerapije { get; set; }
        public int? KartonId { get; set; }

        public virtual ZdravstveniKartoni? Karton { get; set; }
        public virtual ICollection<Recepti> Receptis { get; set; }
    }
}
