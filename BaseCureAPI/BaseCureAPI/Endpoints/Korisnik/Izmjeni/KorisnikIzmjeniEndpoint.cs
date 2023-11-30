using BaseCureAPI.Data;
using BaseCureAPI.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace BaseCureAPI.Endpoints.Korisnik.Izmjeni;

[Route("korisnik")]
public class KorisnikIzmjeniEndpoint : BaseEndpoint<KorisnikIzmjeniRequest, KorisnikIzmjeniResponse>
{
    private readonly ApplicationDbContext _applicationDbContext;

    public KorisnikIzmjeniEndpoint(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [HttpPost("izmjeni")]
    public override async Task<KorisnikIzmjeniResponse> MakeEndpoint([FromBody] KorisnikIzmjeniRequest request, CancellationToken cancellationToken)
    {
        var korisnik = await _applicationDbContext.Korisnik.Where(korisnik => korisnik.ID == request.ID).FirstOrDefaultAsync();

        if (korisnik == null)
        {
            return new KorisnikIzmjeniResponse
            {
                Obavjest = "Nije pronaden korisnik koji ima id: " + request.ID
            };
        }

        korisnik.Ime = request.Ime;
        korisnik.Prezime = request.Prezime;
        korisnik.KorisnickoIme = request.KorisnickoIme;
        korisnik.MailAdresa = request.MailAdresa;
        korisnik.HashLozinke = request.HashLozinke;
        korisnik.Adresa = request.Adresa;
        korisnik.Uloga = request.Uloga;
        korisnik.KontaktBroj = request.KontaktBroj;
        korisnik.DatumRodjenja = request.DatumRodjenja;

        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return new KorisnikIzmjeniResponse
        {
            Obavjest = "Uspjesno izmjenjen korisnik koji ima id: " + request.ID
        };
    }
}