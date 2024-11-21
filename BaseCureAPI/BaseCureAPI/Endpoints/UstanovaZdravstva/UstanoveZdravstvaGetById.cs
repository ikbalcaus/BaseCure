using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using BaseCureAPI.DB;
using BaseCureAPI.Endpoints.UstanovaZdravstva;
using BaseCureAPI.Helpers;
using Microsoft.EntityFrameworkCore;

namespace BaseCureAPI.Endpoints.UstanovaZdravstva.GetById
{
    [Route("ustanoveZdravstva")]
    [ApiController]
    public class UstanoveZdravstvaController : ControllerBase
    {
        private readonly BasecureContext _context;

        public UstanoveZdravstvaController(BasecureContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetUstanovaZdravstva([FromQuery] int id)
        {
            var ustanovaZdravstva = _context.UstanoveZdravstvas.OrderByDescending(x => x.UstanovaId)
                .Where(x => x.UstanovaId == id)
                .Include(x => x.Grad)
                .Select(x => new UstanoveZdravstvaGetByIdRes()
                {
                    UstanovaId = x.UstanovaId,
                    Naziv = x.Naziv,
                    Opis = x.Opis,
                    Adresa = x.Adresa,
                    BrojTelefona = x.BrojTelefona,
                    MailAdresa = x.MailAdresa,
                    Grad = x.Grad.Naziv,
                    TipUstanove = x.TipUstanove.Naziv,
                    CijenaDostave = x.CijenaDostave,
                    Slika = x.Slika
                }).Single();

            return Ok(ustanovaZdravstva);
        }
    }

    public class UstanoveZdravstvaGetByIdRes
    {
        public int UstanovaId { get; set; }
        public string? Naziv { get; set; }
        public string? Opis {  get; set; }
        public string? Adresa { get; set; }
        public string? BrojTelefona { get; set; }
        public string? MailAdresa { get; set; }
        public string? Grad { get; set; }
        public string? TipUstanove { get; set; }
        public float? CijenaDostave {  get; set; }
        public byte[] Slika { get; set; }
    }
}