using System;
using System.Collections.Generic;

namespace BaseCureAPI.DB.Models
{
    public partial class Termini
    {
        public int TerminId { get; set; }
        public DateTime? DatumTermina { get; set; }
        public int? UstanovaId { get; set; }
        public int? PacijentId { get; set; }
        public int? LjekarId { get; set; }

        public virtual Ljekari? Ljekar { get; set; }
        public virtual Pacijenti? Pacijent { get; set; }
        public virtual UstanoveZdravstva? Ustanova { get; set; }
    }
}
