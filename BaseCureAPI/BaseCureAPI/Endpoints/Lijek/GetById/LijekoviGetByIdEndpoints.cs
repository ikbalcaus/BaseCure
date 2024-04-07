using BaseCureAPI.DB;
using BaseCureAPI.DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Endpoints.Lijek.GetById
{
    [Route("lijekovi")]
    [ApiController]
    public class LijekoviGetByIdEndpoints : ControllerBase
    {
        private readonly BasecureContext _context;

        public LijekoviGetByIdEndpoints(BasecureContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult GetLijek([FromRoute] int id)
        {
            var lijek = _context.Lijekovis.FirstOrDefault(x => x.LijekId == id);
            return Ok(lijek);
        }
    }
}
