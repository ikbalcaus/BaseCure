﻿using BaseCureAPI.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Endpoints.GetAll
{
    [Route("gradovi")]
    [ApiController]
    public class GradoviController : ControllerBase
    {
        private readonly BasecureContext _context;

        public GradoviController(BasecureContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetAllResult()
        {
            var results = _context.Gradovis
                .Select(x => new GradoviGetAllRes
                {
                    GradId = x.GradId,
                    Naziv = x.Naziv
                })
                .ToList();
            return Ok(results);
        }
    }

    public class GradoviGetAllRes
    {
        public int? GradId { get; set; }
        public string? Naziv { get; set; }
    }
}