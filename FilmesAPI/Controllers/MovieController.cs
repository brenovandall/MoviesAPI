using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

// using to start api controller -- >
[ApiController]
// every class that has "controller" in the class name ([MovieController] in this case) -- >
[Route("[controller]")]
// ControllBase is an inheritance that needs to be declared in a controller class
public class MovieController : ControllerBase
{
    // using the context class -- > 
    private DataMovieContext _context;
    private IMapper _mapper;
    // ctor of context, then... need to use context props to reference data
    public MovieController(DataMovieContext context)
    {
        _context = context;
    }

    // declaring the api method <get, post, ...>
    [HttpPost]
    public IActionResult AddMovieOnTheList(
        [FromBody] CreateMovieDto movieDto)
    {
        Movie movie = _mapper.Map<Movie>(movieDto);
        // using function " [FromBody] " because the paramether will be declared to the body requisition fields -- >
        _context.Movies.Add(movie);
        _context.SaveChanges();

        // action that create the movie and returns the location of armazenated data -- >
        return CreatedAtAction(nameof(SortMoviesById), 
            new { id = movie.Id }, movie);
    }

    // declaring the api method <get, post, ...>
    [HttpGet]
    public IEnumerable<Movie> GetMoviesList([FromQuery] int skip = 0, [FromQuery] int take = 10) // return all movies that were send with post method
    {
        // in this case, using IEnumerable cause List has inheritance from this, so i can use IEnumarable for all classes that inherit the interface
        return _context.Movies.Skip(skip).Take(take);
    }


    [HttpGet("{id}")]
    public IActionResult SortMoviesById(int id)
    {
        // IActionResult because the interface returns the action that was executed
        var moviesVar = _context.Movies.FirstOrDefault(m => m.Id == id);
        // NotFound ==> 404 NotFound Error
        if (moviesVar == null) return NotFound();
        // OK ==> 200 Ok Success
        return Ok(moviesVar);
    }

}
