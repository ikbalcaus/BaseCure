using System;
using System.Collections.Generic;

namespace BaseCureAPI.DB.Models
{
    public partial class Lijekovi
    {
        public Lijekovi()
        {
            Narudzbes = new HashSet<Narudzbe>();
            Receptis = new HashSet<Recepti>();
        }

        public int LijekId { get; set; }
        public string? Naziv { get; set; }
        public bool? ZahtijevaRecept { get; set; }
        public byte[]? Slika { get; set; }
        public int? UstanovaId { get; set; }
        public string? Opis { get; set; }
        public double? Cijena { get; set; }
        public int? Kolicina { get; set; }

        public virtual UstanoveZdravstva? Ustanova { get; set; }
        public virtual ICollection<Narudzbe> Narudzbes { get; set; }
        public virtual ICollection<Recepti> Receptis { get; set; }
    }
}
