﻿using System;
using System.Collections.Generic;

namespace BaseCureAPI.DB.Models
{
    public partial class UstanoveZdravstva
    {
        public UstanoveZdravstva()
        {
            Lijekovis = new HashSet<Lijekovi>();
            Ljekaris = new HashSet<Ljekari>();
            Osobljes = new HashSet<Osoblje>();
            Terminis = new HashSet<Termini>();
        }

        public int UstanovaId { get; set; }
        public string? Naziv { get; set; }
        public string? Adresa { get; set; }
        public string? KontaktBroj { get; set; }
        public string? Email { get; set; }
        public string? Grad { get; set; }
        public string? Opis { get; set; }

        public virtual ICollection<Lijekovi> Lijekovis { get; set; }
        public virtual ICollection<Ljekari> Ljekaris { get; set; }
        public virtual ICollection<Osoblje> Osobljes { get; set; }
        public virtual ICollection<Termini> Terminis { get; set; }
    }
}
