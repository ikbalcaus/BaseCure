using System;
using System.Collections.Generic;

namespace BaseCureAPI.DB.Models
{
    public partial class Recepti
    {
        public int ReceptId { get; set; }
        public DateTime? DatumReceptiranja { get; set; }
        public int? LijekId { get; set; }
        public int? TerapijaId { get; set; }
        public int? LjekarId { get; set; }

        public virtual Lijekovi? Lijek { get; set; }
        public virtual Ljekari? Ljekar { get; set; }
        public virtual Terapije? Terapija { get; set; }
    }
}
