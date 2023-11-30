using BaseCureAPI.Data;
using BaseCureAPI.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.Korisnik.Izbrisi;

[Route("korisnik")]
public class KorisnikIzbrisiEndpoint : BaseEndpoint<KorisnikIzbrisiRequest, KorisnikIzbrisiResponse>
{
    private readonly ApplicationDbContext _applicationDbContext;

    public KorisnikIzbrisiEndpoint(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [HttpDelete("izbrisi")]
    public override async Task<KorisnikIzbrisiResponse> MakeEndpoint([FromQuery] KorisnikIzbrisiRequest request, CancellationToken cancellationToken)
    {
        var korisnik = await _applicationDbContext.Korisnik.Where(korisnik => korisnik.ID == request.ID).FirstOrDefaultAsync();

        if (korisnik == null)
        {
            return new KorisnikIzbrisiResponse
            {
                Obavjest = "Nije pronaden korisnik koji ima id: " + request.ID
            };
        }

        _applicationDbContext.Korisnik.Remove(korisnik);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return new KorisnikIzbrisiResponse
        {
            Obavjest = "Uspjesno izbrisan korisnik koji ima id: " + request.ID
        };
    }
}