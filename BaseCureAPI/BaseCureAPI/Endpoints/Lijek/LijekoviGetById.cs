using BaseCureAPI.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Endpoints.Lijek.GetById
{
    [Route("lijekovi")]
    [ApiController]
    public class LijekoviController : ControllerBase
    {
        private readonly BasecureContext _context;

        public LijekoviController(BasecureContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult GetLijek([FromRoute] int id)
        {
            var lijek = _context.Lijekovis.Find(id);
            return Ok(lijek);
        }
    }

    public class LijekoviGetByIdRes
    {
        public int LijekId { get; set; }
        public string? Naziv { get; set; }
        public bool? ZahtijevaRecept { get; set; }
        public byte[]? Slika { get; set; }
        public int? UstanovaId { get; set; }
        public float? Cijena { get; set; }
        public int? Kolicina { get; set; }
        public string? Opis { get; set; }
    }
}
