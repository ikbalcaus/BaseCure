using BaseCureAPI.Data;
using BaseCureAPI.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.Korisnik.Pretrazi;

[Route("korisnik")]
public class KorisnikPretraziEndpoint : BaseEndpoint<KorisnikPretraziRequest, KorisniciPretraziResponse>
{
    private readonly ApplicationDbContext _applicationDbContext;

    public KorisnikPretraziEndpoint(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [HttpGet("pretrazi")]
    public override async Task<KorisniciPretraziResponse> MakeEndpoint([FromQuery] KorisnikPretraziRequest request, CancellationToken cancellation)
    {
        var korisnici = await _applicationDbContext.Korisnik
            .Where(korisnik => korisnik.KorisnickoIme.ToLower().Contains(request.KorisnickoIme.ToLower()))
            .Select(korisnik => new KorisnikPretraziResponse()
            {
                Ime = korisnik.Ime,
                Prezime = korisnik.Prezime,
                KorisnickoIme = korisnik.KorisnickoIme,
                MailAdresa = korisnik.MailAdresa,
                HashLozinke = korisnik.HashLozinke,
                Adresa = korisnik.Adresa,
                Uloga = korisnik.Uloga,
                KontaktBroj = korisnik.KontaktBroj,
                DatumRodjenja = korisnik.DatumRodjenja
            }).ToListAsync();

        return new KorisniciPretraziResponse
        {
            Korisnici = korisnici
        };
    }
}