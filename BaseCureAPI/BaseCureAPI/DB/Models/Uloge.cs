using System;
using System.Collections.Generic;

namespace BaseCureAPI.DB.Models
{
    public partial class Uloge
    {
        public Uloge()
        {
            Osobljes = new HashSet<Osoblje>();
        }

        public int UlogaId { get; set; }
        public string? Naziv { get; set; }

        public virtual ICollection<Osoblje> Osobljes { get; set; }
    }
}
