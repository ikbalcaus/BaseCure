using System;
using System.Collections.Generic;

namespace BaseCureAPI.DB.Models
{
    public partial class Ljekari
    {
        public Ljekari()
        {
            Osobljes = new HashSet<Osoblje>();
            Pregledis = new HashSet<Pregledi>();
            Receptis = new HashSet<Recepti>();
            Terminis = new HashSet<Termini>();
        }

        public int LjekarId { get; set; }
        public string? Specijalizacija { get; set; }
        public string? Opis { get; set; }
        public byte[]? Slika { get; set; }

        public virtual ICollection<Osoblje> Osobljes { get; set; }
        public virtual ICollection<Pregledi> Pregledis { get; set; }
        public virtual ICollection<Recepti> Receptis { get; set; }
        public virtual ICollection<Termini> Terminis { get; set; }
    }
}
