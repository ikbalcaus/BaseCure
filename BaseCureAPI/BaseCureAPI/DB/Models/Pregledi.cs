using System;
using System.Collections.Generic;

namespace BaseCureAPI.DB.Models
{
    public partial class Pregledi
    {
        public Pregledi()
        {
            ZdravstveniKartonis = new HashSet<ZdravstveniKartoni>();
        }

        public int PregledId { get; set; }
        public DateTime? DatumPregleda { get; set; }
        public string? Rezultati { get; set; }
        public int? DijagnozaId { get; set; }
        public int? LjekarId { get; set; }

        public virtual Dijagnoze? Dijagnoza { get; set; }
        public virtual Ljekari? Ljekar { get; set; }
        public virtual ICollection<ZdravstveniKartoni> ZdravstveniKartonis { get; set; }
    }
}
