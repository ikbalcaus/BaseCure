using System;
using System.Collections.Generic;

namespace BaseCureAPI.DB.Models
{
    public partial class Dijagnoze
    {
        public Dijagnoze()
        {
            Pregledis = new HashSet<Pregledi>();
        }

        public int DijagnozaId { get; set; }
        public string? NazivDijagnoze { get; set; }
        public DateTime? DatumDijagnoze { get; set; }

        public virtual ICollection<Pregledi> Pregledis { get; set; }
    }
}
