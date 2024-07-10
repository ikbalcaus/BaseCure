using System;
using System.Collections.Generic;

namespace BaseCureAPI.DB.Models
{
    public partial class ZdravstveniKartoni
    {
        public ZdravstveniKartoni()
        {
            LaboratorijskiRezultatis = new HashSet<LaboratorijskiRezultati>();
            Napomenes = new HashSet<Napomene>();
            Terapijes = new HashSet<Terapije>();
        }

        public int KartonId { get; set; }
        public DateTime? DatumIzdavanja { get; set; }
        public string? Sadrzaj { get; set; }
        public int? PacijentId { get; set; }
        public int? PregledId { get; set; }

        public virtual Pacijenti? Pacijent { get; set; }
        public virtual Pregledi? Pregled { get; set; }
        public virtual ICollection<LaboratorijskiRezultati> LaboratorijskiRezultatis { get; set; }
        public virtual ICollection<Napomene> Napomenes { get; set; }
        public virtual ICollection<Terapije> Terapijes { get; set; }
    }
}
