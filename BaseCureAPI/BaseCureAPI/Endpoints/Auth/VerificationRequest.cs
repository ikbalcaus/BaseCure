namespace BaseCureAPI.Endpoints.Auth
{
    public class VerificationRequest
    {
        public string UserId { get; set; }
        public string VerificationCode { get; set; }
    }
}
