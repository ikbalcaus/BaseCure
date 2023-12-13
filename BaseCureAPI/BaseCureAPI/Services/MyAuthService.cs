using BaseCureAPI.DB;
using BaseCureAPI.DB.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace BaseCureAPI.Services
{
    public class MyAuthService
    {
        private readonly BasecureContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MyAuthService(BasecureContext applicationDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _context = applicationDbContext;
            _httpContextAccessor = httpContextAccessor;
        }
        public bool JelLogiran()
        {
            return GetAuthInfo().IsLogiran;
        }

        public MyAuthInfo GetAuthInfo()
        {
            string? authToken = _httpContextAccessor.HttpContext!.Request.Headers["my-auth-token"];

            AuthToken? autentifikacijaToken = _context.AuthTokens
                .Include(x => x.Korisnik)
                .SingleOrDefault(x => x.Vrijednost == authToken);

            return new MyAuthInfo(autentifikacijaToken);
        }

        public class MyAuthInfo
        {
            public MyAuthInfo(AuthToken? autentifikacijaToken)
            {
                this.AutentifikacijaToken = autentifikacijaToken;
            }

            [JsonIgnore]
            public Korisnici? Korisnici => AutentifikacijaToken?.Korisnik;
            public AuthToken? AutentifikacijaToken { get; set; }

            public bool IsLogiran => Korisnici != null;

        }
    }
}
