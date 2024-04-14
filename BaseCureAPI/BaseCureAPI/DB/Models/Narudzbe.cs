using System;
using System.Collections.Generic;

namespace BaseCureAPI.DB.Models
{
    public partial class Narudzbe
    {
        public int NarudzbaId { get; set; }
        public int? KorisnikId { get; set; }
        public int? LijekId { get; set; }
        public DateTime? DatumVrijeme { get; set; }
        public bool? Odobreno { get; set; }

        public virtual Korisnici? Korisnik { get; set; }
        public virtual Lijekovi? Lijek { get; set; }
    }
}
