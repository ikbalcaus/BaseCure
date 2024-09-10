using BaseCureAPI.DB.Models;
using BaseCureAPI.DB;
using BaseCureAPI.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;

public interface IAuthService
{
    Task<string> AuthenticateUser(string username, string password);
    bool IsAuthorized(ClaimsPrincipal user, string role);
}

public class AuthService : IAuthService
{
    private readonly BasecureContext _context;
    private readonly AuthOptions _authOptions;

    public AuthService(BasecureContext context, IOptions<AuthOptions> authOptions)
    {
        _context = context;
        _authOptions = authOptions.Value;
    }

    public async Task<string> AuthenticateUser(string mail, string password)
    {
        var user = await _context.Korisnicis
            .Include(k => k.Osoblje)
            .ThenInclude(o => o.Uloga)
            .SingleOrDefaultAsync(x => x.MailAdresa == mail);

        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.HashLozinke))
            return null;

        return GenerateJwtToken(user);
    }

    private string GenerateJwtToken(Korisnici user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_authOptions.Secret);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.KorisnikId.ToString()),
                new Claim(ClaimTypes.Role, user.Osoblje?.Uloga?.Naziv ?? "")
            }),
            Expires = DateTime.UtcNow.AddMinutes(_authOptions.ExpirationMinutes),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public bool IsAuthorized(ClaimsPrincipal user, string role)
    {
        return user.IsInRole(role);
    }
}
