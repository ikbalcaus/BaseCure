using Microsoft.AspNetCore.Mvc;
using BaseCureAPI.DB.Models;
using System.Collections.Generic;
using System.Linq;
using BaseCureAPI.DB;
using BaseCureAPI.Endpoints.UstanovaZdravstva;
using BaseCureAPI.Helpers;

namespace BaseCureAPI.Endpoints.UstanovaZdravstva.Delete
{
    [Route("ustanveZdravstva")]
    [ApiController]
    public class UstanoveZdravstvaDeleteController : ControllerBase
    {
        private readonly BasecureContext _context;

        public UstanoveZdravstvaDeleteController(BasecureContext context)
        {
            _context = context;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUstanova(int id)
        {
            var ustanova = _context.UstanoveZdravstvas.Find(id);
            if (ustanova == null)
            {
                return NotFound();
            }

            _context.UstanoveZdravstvas.Remove(ustanova);
            _context.SaveChanges();

            return NoContent();
        }
    }
}