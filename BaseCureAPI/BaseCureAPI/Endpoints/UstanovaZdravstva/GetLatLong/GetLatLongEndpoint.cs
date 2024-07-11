using BaseCureAPI.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Endpoints.UstanovaZdravstva.GetLatLong
{
    [Route("ustanova/latlong")]
    [ApiController]
    public class UstanoveZdravstvaController : ControllerBase
    {
        private readonly BasecureContext _context;

        public UstanoveZdravstvaController(BasecureContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var ustanova = _context.UstanoveZdravstvas.Where(x => x.UstanovaId == id)
                .Select(x => new GetLatLongRes()
                {
                    Lat = x.Latitude,
                    Long = x.Longitude
                }).FirstOrDefault();

            return Ok(ustanova);
        }   
    }
}
