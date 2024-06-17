using System;
using System.Collections.Generic;

namespace BaseCureAPI.DB.Models
{
    public partial class Napomene
    {
        public int NapomenaId { get; set; }
        public string? NaslovNapomene { get; set; }
        public string? TekstNapomene { get; set; }
        public DateTime? DatumKreiranja { get; set; }
        public int? KartonId { get; set; }

        public virtual ZdravstveniKartoni? Karton { get; set; }
    }
}
