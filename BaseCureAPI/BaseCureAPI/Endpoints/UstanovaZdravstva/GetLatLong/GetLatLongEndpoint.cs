using BaseCureAPI.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Endpoints.UstanovaZdravstva.GetLatLong
{
    [Route("ustanova/latlang")]
    [ApiController]
    public class GetLatLongEndpoint : ControllerBase
    {
        private readonly BasecureContext _context;

        public GetLatLongEndpoint(BasecureContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Get([FromQuery] int ustanovaid)
        {
            var ustanova = _context.UstanoveZdravstvas.Where(x => x.UstanovaId == ustanovaid)
                .Select(x => new GetLatLongRes()
                {
                    UstanovaId = x.UstanovaId,
                    Lat = x.Latitude,
                    Long = x.Longitude
                }).FirstOrDefault();

            return Ok(ustanova);
        }   
    }
}
