using BaseCureAPI.DB;
using BaseCureAPI.DB.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace BaseCureAPI.Services
{
    public class AuthService
    {
        private readonly BasecureContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(BasecureContext applicationDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _context = applicationDbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public bool IsAuthorized(string role)
        {
            string authTokenFromHeader = _httpContextAccessor.HttpContext!.Request.Headers["Auth-Token"];

            if(authTokenFromHeader == "") return false;

            AuthToken? authTokenFromDB = _context.AuthTokens
                .Include(x => x.Korisnik)
                .SingleOrDefault(x => x.Vrijednost == authTokenFromHeader);

            return (authTokenFromDB?.Korisnik?.Uloga == role); 
            // Provjeriti da li radi
        }

        public AuthToken GetAuthInfo()
        {
            string authTokenFromHeader = _httpContextAccessor.HttpContext!.Request.Headers["Auth-Token"];

            AuthToken? authTokenFromDB = _context.AuthTokens
                .Include(x => x.Korisnik)
                .SingleOrDefault(x => x.Vrijednost == authTokenFromHeader);

            return authTokenFromDB!;
        }
    }
}
