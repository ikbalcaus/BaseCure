using Microsoft.AspNetCore.Mvc;
using BaseCureAPI.DB.Models;
using System.Collections.Generic;
using System.Linq;
using BaseCureAPI.DB;
using BaseCureAPI.Endpoints.Korisnik;
using BaseCureAPI.Endpoints.UstanovaZdravstva;
using BaseCureAPI.Helpers;

[Route("ustanveZdravstva")]
[ApiController]
public class UstanoveZdravstvaController : ControllerBase
{
    private readonly BasecureContext _context; 

    public UstanoveZdravstvaController(BasecureContext context)
    {
        _context = context;
    }

    [HttpPost("create")]
    public ActionResult<int> CreateUstanova([FromBody] UstanoveZdravstvaReq req)
    {
        UstanoveZdravstva ustanova = new UstanoveZdravstva();
        ustanova.UstanovaId = _context.UstanoveZdravstvas.Any() ? _context.UstanoveZdravstvas.Max(x => x.UstanovaId) + 1 : 1;
        ustanova.Naziv = req.Naziv.RemoveTags();
        ustanova.Grad = req.Grad.RemoveTags();
        _context.UstanoveZdravstvas.Add(ustanova);
        _context.SaveChanges();
        return ustanova.UstanovaId;
    }

    [HttpPost("search")]
    public ActionResult<UstanoveZdravstvaRes> GetUstanova([FromBody] UstanoveZdravstvaReq req)
    {
        var ustanove = _context.UstanoveZdravstvas.OrderByDescending(x => x.UstanovaId)
            .Where(x => x.Naziv.Contains(req.Naziv) && (x.Grad == req.Grad || req.Grad == ""))
            .Select(x => new UstanoveZdravstvaRes()
            {
                Naziv = x.Naziv,
                Grad = x.Grad,
            }).ToList();
        return Ok(ustanove);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUstanova(int id, [FromBody] UstanoveZdravstvaRes ustanova)
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