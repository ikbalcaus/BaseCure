using System;
using System.Collections.Generic;

namespace BaseCureAPI.DB.Models
{
    public partial class Osoblje
    {
        public int OsobljeId { get; set; }
        public string? PunoIme { get; set; }
        public string? Uloga { get; set; }
        public int? UstanovaId { get; set; }
        public int? KorisnikId { get; set; }

        public virtual Korisnici? Korisnik { get; set; }
        public virtual UstanoveZdravstva? Ustanova { get; set; }
    }
}
