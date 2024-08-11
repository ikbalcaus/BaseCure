using BaseCureAPI.DB;
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
        var korisnik = await _context.Korisnicis
            .FirstOrDefaultAsync(k => k.KorisnikId == primaocId);

        if (korisnik != null && korisnik.KonekcijskiId != null)
        {
            await Clients.Client(korisnik.KonekcijskiId).SendAsync("ReceiveMessage", posiljaocId, poruka);
        }
    }
}
