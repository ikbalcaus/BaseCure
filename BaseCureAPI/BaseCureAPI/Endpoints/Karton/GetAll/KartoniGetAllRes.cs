using BaseCureAPI.DB.Models;
using BaseCureAPI.Endpoints.Korisnik.GetAll;

namespace BaseCureAPI.Endpoints.Karton.GetAll
{
    public class KartoniGetAllRes
    {
        public DateTime? DatumIzdavanja { get; set; }
        public int? PacijentId { get; set; }
        public Pacijenti Pacijent { get; set; }
        public Korisnici Korisnik { get; set; }
    }
}
