using System;
using System.Collections.Generic;

namespace BaseCureAPI.DB.Models
{
    public partial class Gradovi
    {
        public Gradovi()
        {
            Korisnicis = new HashSet<Korisnici>();
            Narudzbes = new HashSet<Narudzbe>();
            UstanoveZdravstvas = new HashSet<UstanoveZdravstva>();
        }

        public int GradId { get; set; }
        public string? Naziv { get; set; }
        public string? Drzava { get; set; }

        public virtual ICollection<Korisnici> Korisnicis { get; set; }
        public virtual ICollection<Narudzbe> Narudzbes { get; set; }
        public virtual ICollection<UstanoveZdravstva> UstanoveZdravstvas { get; set; }
    }
}
