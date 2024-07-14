﻿using BaseCureAPI.DB;
using BaseCureAPI.Endpoints.Grad.GetAll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Endpoints.Autocomplete.Grad
{
    [Route("autocomplete")]
    [ApiController]
    public class GradoviController : ControllerBase
    {
        private readonly BasecureContext _context;

        public GradoviController(BasecureContext context)
        {
            _context = context;
        }

        [HttpGet("grad")]
        public ActionResult GetSearchResult([FromQuery] string? naziv)
        {
            var results = _context.Gradovis
                .Where(x => x.Naziv.Contains(naziv)).Select(x => x.Naziv).Take(5).ToList();
            return Ok(results);
        }
    }
}
