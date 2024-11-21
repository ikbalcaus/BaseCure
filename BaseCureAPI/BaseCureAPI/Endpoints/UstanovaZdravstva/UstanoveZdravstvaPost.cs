using Microsoft.AspNetCore.Mvc;
using BaseCureAPI.DB.Models;
using System.Collections.Generic;
using System.Linq;
using BaseCureAPI.DB;
using BaseCureAPI.Endpoints.UstanovaZdravstva;
using BaseCureAPI.Helpers;

namespace BaseCureAPI.Endpoints.UstanovaZdravstva.Post
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

        [HttpPost]
        public ActionResult CreateUstanova([FromBody] UstanoveZdravstvaPostReq req)
        {
            UstanoveZdravstva ustanova = new UstanoveZdravstva();
            ustanova.UstanovaId = _context.UstanoveZdravstvas.Any() ? _context.UstanoveZdravstvas.Max(x => x.UstanovaId) + 1 : 1;
            ustanova.Naziv = req.Naziv.RemoveTags();
            ustanova.Grad.Naziv = req.Grad.RemoveTags();
            _context.UstanoveZdravstvas.Add(ustanova);
            _context.SaveChanges();
            return NoContent();
        }
    }

    public class UstanoveZdravstvaPostReq
    {
        public int UstanovaId { get; set; }
        public string Naziv { get; set; }
        public string Grad { get; set; }
    }

    public class UstanoveZdravstvaPostRes
    {
        public int? UstanovaId { get; set; } 
        public string? Naziv { get; set; }
        public string? Adresa { get; set; }
        public string? BrojTelefona { get; set; }
        public string? MailAdresa { get; set; }
        public string? Grad { get;set; }
    }
}