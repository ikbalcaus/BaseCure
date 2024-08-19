using BaseCureAPI.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Endpoints.UstanovaZdravstva.Patch
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

        [HttpPatch("{id}")]
        public ActionResult Put([FromRoute] int id, [FromBody] PatchReq putLatLongReq)
        {
            var ustanova = _context.UstanoveZdravstvas.Find(id);
            ustanova.Latitude = putLatLongReq.Lat;
            ustanova.Longitude = putLatLongReq.Long;
            _context.SaveChanges();
            return NoContent();
        }   
    }
}
