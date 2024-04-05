namespace BaseCureAPI.Endpoints.Login
{
    public class VerificationRequest
    {
        public string UserId { get; set; }
        public string VerificationCode { get; set; }
    }
}
