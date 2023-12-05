using System;
using System.Collections.Generic;

namespace BaseCureAPI.DB.Models
{
    public partial class LaboratorijskiRezultati
    {
        public int RezultatId { get; set; }
        public string? VrstaAnalize { get; set; }
        public string? RezultatiAnalize { get; set; }
        public DateTime? DatumAnalize { get; set; }
        public int? KartonId { get; set; }

        public virtual ZdravstveniKartoni? Karton { get; set; }
    }
}
