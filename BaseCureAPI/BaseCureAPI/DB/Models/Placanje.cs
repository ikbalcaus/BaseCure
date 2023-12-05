using System;
using System.Collections.Generic;

namespace BaseCureAPI.DB.Models
{
    public partial class Placanje
    {
        public int PlacanjeId { get; set; }
        public decimal? Iznos { get; set; }
        public DateTime? DatumPlacanja { get; set; }
        public int? PacijentId { get; set; }

        public virtual Pacijenti? Pacijent { get; set; }
    }
}
