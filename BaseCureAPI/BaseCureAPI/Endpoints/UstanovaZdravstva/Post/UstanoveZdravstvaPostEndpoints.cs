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
}