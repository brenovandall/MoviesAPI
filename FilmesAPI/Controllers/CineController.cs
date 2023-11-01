using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FislmesAPI.Data.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CineController : ControllerBase
{

    private DataMovieContext _context;
    private IMapper _mapper;

    public CineController(DataMovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpPost]
    public IActionResult AddCine([FromBody] CreateCineDto cineDto)
    {
        Cine cine = _mapper.Map<Cine>(cineDto);

        _context.Cines.Add(cine);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetCineById), new { id = cine.Id }, cine);
    }

    [HttpGet]
    public IEnumerable<ReadCineDto> GetAllCines([FromQuery] int? addressid = null)
    {
        if (addressid == null)
        {
            return _mapper.Map<List<ReadCineDto>>(_context.Cines.ToList());
        } else
        {
            return _mapper.Map<List<ReadCineDto>>(_context.Cines
                .FromSqlRaw($"SELECT Id, Name, AddressId FROM cines WHERE cines.Id = {addressid}").ToList());
        }
        
    }

    [HttpGet("{id}")]
    public IActionResult GetCineById(int id)
    {
        var cinevar = _context.Cines.FirstOrDefault(x => x.Id == id);
        if (cinevar == null)
        {
            return NotFound();
        }
        return Ok(cinevar);
    }

    [HttpPut("{index}")]
    public IActionResult UpdateCine(int index, [FromQuery] UpdateMovieDto updated)
    {
        var cinevar = _context.Cines.FirstOrDefault(x => x.Id == index);
        if (cinevar == null)
        {
            return NotFound();
        }
        _mapper.Map(updated, cinevar);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{position}")]
    public IActionResult DeleteCine(int position)
    {
        var cinevar = _context.Cines.FirstOrDefault(x => x.Id == position);
        if (cinevar == null)
        {
            return NotFound();
        }
        _context.Remove(cinevar);
        _context.SaveChanges();
        return NoContent();
    }
}
