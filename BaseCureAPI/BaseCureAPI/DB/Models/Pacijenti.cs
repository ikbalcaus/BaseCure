using System;
using System.Collections.Generic;

namespace BaseCureAPI.DB.Models
{
    public partial class Pacijenti
    {
        public Pacijenti()
        {
            Terminis = new HashSet<Termini>();
            ZdravstveniKartonis = new HashSet<ZdravstveniKartoni>();
        }

        public int PacijentId { get; set; }
        public decimal? Tezina { get; set; }
        public decimal? Visina { get; set; }
        public string? KrvnaGrupa { get; set; }
        public int? PritisakSistolicki { get; set; }
        public int? PritisakDistolicki { get; set; }
        public int? Pulz { get; set; }
        public string? Alergije { get; set; }
        public string? TrenutneBolesti { get; set; }
        public string? RanijeBolesti { get; set; }
        public string? Lijekovi { get; set; }
        public string? PorodicnaAnamneza { get; set; }
        public string? NavikePonasanja { get; set; }
        public int? KorisnikId { get; set; }

        public virtual Korisnici? Korisnik { get; set; }
        public virtual ICollection<Termini> Terminis { get; set; }
        public virtual ICollection<ZdravstveniKartoni> ZdravstveniKartonis { get; set; }
    }
}
