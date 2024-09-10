namespace BaseCureAPI.Services
{
    public class AuthOptions
    {
        public string Secret { get; set; }
        public int ExpirationMinutes { get; set; }
    }
}
