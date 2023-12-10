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
    private readonly BaseCureContext _context; 

    public UstanoveZdravstvaController(BaseCureContext context)
    {
        _context = context;
    }

    [HttpPost]
    public ActionResult<int> CreateUstanova([FromBody] UstanoveZdravstvaReq req)
    {
        UstanoveZdravstva? ustanova;

        if (req.ID == 0)
        {
            ustanova = new UstanoveZdravstva();
            _context.Add(ustanova);
        }
        else
        {
            ustanova = _context.UstanoveZdravstvas.FirstOrDefault(x => x.UstanovaId == req.ID);
            if (ustanova == null)
                throw new Exception("wrong ID");
        }

        ustanova.Naziv = req.Naziv.RemoveTags();

        _context.SaveChanges();

        return ustanova.UstanovaId;
    }

    [HttpGet]
    public ActionResult<UstanoveZdravstvaResponseGetAll> GetAllUstanove()
    {
        var ustanove = _context.UstanoveZdravstvas.OrderByDescending(x => x.UstanovaId)
                .Select(x => new UstanoveZdravstvaRes()
                {
                    UstanovaId = x.UstanovaId,
                    Naziv = x.Naziv,
                    Adresa = x.Adresa,
                    KontaktBroj = x.KontaktBroj,
                    Email = x.Email,
                    Grad = x.Grad,
                }).ToList();
        return new UstanoveZdravstvaResponseGetAll()
        {
            Ustanove = ustanove
        };
    }

    [HttpGet("{id}")]
    public ActionResult<UstanoveZdravstvaRes> GetUstanova(int id)
    {
        var ustanova = _context.UstanoveZdravstvas.OrderByDescending(x => x.UstanovaId)
                .Select(x => new UstanoveZdravstvaRes()
                {
                    UstanovaId = x.UstanovaId,
                    Naziv = x.Naziv,
                    Adresa = x.Adresa,
                    KontaktBroj = x.KontaktBroj,
                    Email = x.Email,
                    Grad = x.Grad,
                }).Single(x=> x.UstanovaId == id);
        if (ustanova == null)
        {
            return NotFound();
        }

        return ustanova;
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