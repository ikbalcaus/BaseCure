using BaseCureAPI.DB;
using BaseCureAPI.DB.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

public class ChatHub : Hub
{
    private readonly BasecureContext _context;

    public ChatHub(BasecureContext context)
    {
        _context = context;
    }

    public override async Task OnDisconnectedAsync(System.Exception exception)
    {
        var korisnik = await _context.Korisnicis
            .FirstOrDefaultAsync(k => k.KonekcijskiId == Context.ConnectionId);

        if (korisnik != null)
        {
            korisnik.KonekcijskiId = null;
            await _context.SaveChangesAsync();
        }

        await base.OnDisconnectedAsync(exception);
    }

    public async Task SendMessageToUser(int posiljaocId, int primaocId, string poruka)
    {
        var primaoc = await _context.Korisnicis
            .FirstOrDefaultAsync(k => k.KorisnikId == primaocId);
        var datumVrijeme = DateTime.Now;

        var poruke = await _context.Porukes.AddAsync(new Poruke
        {
            PorukaId = _context.Porukes.Any() ? _context.Porukes.Max(x => x.PorukaId) + 1 : 1,
            PosiljaocId = posiljaocId,
            PrimaocId = primaocId,
            Poruka = poruka,
            Procitana = false,
            DatumVrijeme = datumVrijeme,
        });
        await _context.SaveChangesAsync();

        if (primaoc != null && primaoc.KonekcijskiId != null)
        {
            await Clients.Client(primaoc.KonekcijskiId).SendAsync("ReceiveMessage", posiljaocId, poruka, datumVrijeme);
        }
    }
}
