namespace BaseCureAPI.Endpoints.Login
{
    public class AuthLoginRes
    {
        public string? Vrijednost { get; set; }
        public DateTime? VrijemeEvidentiranja { get; set; }
        public string? IpAdresa { get; set; }
        public string? Code2f { get; set; }
        public string? Is2fOtkljucan { get; set; }
    }
}
