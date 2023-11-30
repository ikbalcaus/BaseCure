using BaseCureAPI.Data;
using BaseCureAPI.Helper;
using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Endpoints.Korisnik.Dodaj;

[Route("korisnik")]
public class KorisnikDodajEndpoint : BaseEndpoint<KorisnikDodajRequest, KorisnikDodajResponse>
{
    private readonly ApplicationDbContext _applicationDbContext;

    public KorisnikDodajEndpoint(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [HttpPost("dodaj")]
    public override async Task<KorisnikDodajResponse> MakeEndpoint([FromBody] KorisnikDodajRequest request, CancellationToken cancellationToken)
    {
        var newObj = new Data.Models.Korisnik
        {
            Ime = request.Ime,
            Prezime = request.Prezime,
            KorisnickoIme = request.KorisnickoIme,
            MailAdresa = request.MailAdresa,
            HashLozinke = request.HashLozinke,
            Adresa = request.Adresa,
            Uloga = request.Uloga,
            KontaktBroj = request.KontaktBroj,
            DatumRodjenja = request.DatumRodjenja,
        };

        _applicationDbContext.Korisnik.Add(newObj);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return new KorisnikDodajResponse
        {
            ImePrezime = newObj.Ime + " " + newObj.Prezime
        };
    }
}