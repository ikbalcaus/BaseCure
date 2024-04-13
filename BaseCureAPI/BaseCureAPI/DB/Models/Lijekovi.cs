using System;
using System.Collections.Generic;

namespace BaseCureAPI.DB.Models
{
    public partial class Lijekovi
    {
        public Lijekovi()
        {
            LijekoviKorisnicis = new HashSet<LijekoviKorisnici>();
            Receptis = new HashSet<Recepti>();
        }

        public int LijekId { get; set; }
        public string? NazivLijeka { get; set; }
        public bool? ZahtijevaRecept { get; set; }
        public byte[]? SlikaLijeka { get; set; }
        public int? UstanovaId { get; set; }
        public string? OpisLijeka { get; set; }
        public double? CijenaLijeka { get; set; }
        public int? Kolicina { get; set; }

        public virtual UstanoveZdravstva? Ustanova { get; set; }
        public virtual ICollection<LijekoviKorisnici> LijekoviKorisnicis { get; set; }
        public virtual ICollection<Recepti> Receptis { get; set; }
    }
}
