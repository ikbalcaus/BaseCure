using BaseCureAPI.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Endpoints.UstanovaZdravstva.PutLatLong
{
    [Route("ustanoveZdravstva/latlong")]
    [ApiController]
    public class UstanoveZdravstvaController : ControllerBase
    {
        private readonly BasecureContext _context;

        public UstanoveZdravstvaController(BasecureContext context)
        {
            _context = context;
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromRoute] int id, [FromBody] PutLatLongReq putLatLongReq)
        {
            var ustanova = _context.UstanoveZdravstvas.FirstOrDefault(x => x.UstanovaId == id);
            ustanova.Latitude = putLatLongReq.Lat;
            ustanova.Longitude = putLatLongReq.Long;
            _context.SaveChanges();
            return NoContent();
        }   
    }
}
