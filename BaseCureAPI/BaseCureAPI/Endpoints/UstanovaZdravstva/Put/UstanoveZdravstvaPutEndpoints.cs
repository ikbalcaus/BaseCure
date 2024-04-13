using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using BaseCureAPI.DB;
using BaseCureAPI.Endpoints.UstanovaZdravstva;
using BaseCureAPI.Helpers;

namespace BaseCureAPI.Endpoints.UstanovaZdravstva.Put
{
    [Route("ustanveZdravstva")]
    [ApiController]
    public class UstanoveZdravstvaController : ControllerBase
    {
        private readonly BasecureContext _context;

        public UstanoveZdravstvaController(BasecureContext context)
        {
            _context = context;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUstanova(int id, [FromBody] UstanoveZdravstvaPutReq ustanova)
        {
            if (id != ustanova.UstanovaId)
            {
                return BadRequest();
            }

            _context.Entry(ustanova).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }
    }
}