using BaseCureAPI.DB.Models;
using BaseCureAPI.Endpoints.Korisnik.GetAll;

namespace BaseCureAPI.Endpoints.MedicalRecords.GetAllRecords
{
    public class MedicalRecordsGetAllRes
    {
        public int KartonId { get; set; }
        public DateTime? DatumIzdavanja { get; set; }
        public int? PacijentId { get; set; }
        public Pacijenti Pacijent { get; set; }
        public Korisnici Korisnik { get; set; }
    }

    public class RecordsGetAllResList
    {
        public List<MedicalRecordsGetAllRes> Kartoni { get; set; }
    }
}
