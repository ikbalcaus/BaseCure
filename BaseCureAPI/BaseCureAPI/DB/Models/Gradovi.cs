using System;
using System.Collections.Generic;

namespace BaseCureAPI.DB.Models
{
    public partial class Gradovi
    {
        public Gradovi()
        {
            Korisnicis = new HashSet<Korisnici>();
        }

        public int GradId { get; set; }
        public string? Naziv { get; set; }
        public string? Entitet { get; set; }

        public virtual ICollection<Korisnici> Korisnicis { get; set; }
    }
}
