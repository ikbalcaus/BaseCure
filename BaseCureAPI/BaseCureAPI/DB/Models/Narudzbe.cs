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
        public string? ImePrezime { get; set; }
        public string? BrojTelefona { get; set; }
        public int? GradId { get; set; }
        public string? Adresa { get; set; }
        public string? MailAdresa { get; set; }
        public int? RedniBroj { get; set; }
        public string? Status { get; set; }

        public virtual Gradovi? Grad { get; set; }
        public virtual Korisnici? Korisnik { get; set; }
        public virtual Lijekovi? Lijek { get; set; }
    }
}
