namespace BaseCureAPI.Endpoints.Uputnica.GetAll
{
    public class UputniceGetAllRes
    {
        public int PatientId { get; set; }
        public string PatientName { get; set;}
        public string MedicalRecords { get; set;}
        public object Therapies { get; internal set; }
    }

    public class TerapijaDto
    {
        public int TherapyId { get; set; } 
        public string TherapyName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
