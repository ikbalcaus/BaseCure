using System;
using System.Collections.Generic;

namespace BaseCureAPI.DB.Models
{
    public partial class TipoviUstanova
    {
        public TipoviUstanova()
        {
            UstanoveZdravstvas = new HashSet<UstanoveZdravstva>();
        }

        public int TipUstanoveId { get; set; }
        public string? Naziv { get; set; }

        public virtual ICollection<UstanoveZdravstva> UstanoveZdravstvas { get; set; }
    }
}
