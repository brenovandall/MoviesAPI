using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FislmesAPI.Data.Dtos;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult UpdateCine(int index, [FromBody] UpdateMovieDto updated)
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
