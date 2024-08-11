using System;
using System.Collections.Generic;

namespace BaseCureAPI.DB.Models
{
    public partial class Poruke
    {
        public int PorukaId { get; set; }
        public int PosiljaocId { get; set; }
        public int PrimaocId { get; set; }
        public string Poruka { get; set; } = null!;
        public bool Procitana { get; set; }
        public DateTime DatumVrijeme { get; set; }

        public virtual Korisnici Posiljaoc { get; set; } = null!;
        public virtual Korisnici Primaoc { get; set; } = null!;
    }
}
