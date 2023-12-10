using Microsoft.AspNetCore.Mvc;
using BaseCureAPI.DB.Models;
using System.Collections.Generic;
using System.Linq;
using BaseCureAPI.DB;

[Route("ustanveZdravstva")]
[ApiController]
public class UstanoveZdravstvaController : ControllerBase
{
    private readonly BaseCureContext _context; 

    public UstanoveZdravstvaController(BaseCureContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult CreateUstanova([FromBody] UstanoveZdravstva ustanova)
    {
        _context.UstanoveZdravstvas.Add(ustanova);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetUstanova), new { id = ustanova.UstanovaId }, ustanova);
    }

    [HttpGet]
    public ActionResult<IEnumerable<UstanoveZdravstva>> GetAllUstanove()
    {
        return _context.UstanoveZdravstvas.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<UstanoveZdravstva> GetUstanova(int id)
    {
        var ustanova = _context.UstanoveZdravstvas.Find(id);

        if (ustanova == null)
        {
            return NotFound();
        }

        return ustanova;
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUstanova(int id, [FromBody] UstanoveZdravstva ustanova)
    {
        if (id != ustanova.UstanovaId)
        {
            return BadRequest();
        }

        _context.Entry(ustanova).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        _context.SaveChanges();

        return NoContent();
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