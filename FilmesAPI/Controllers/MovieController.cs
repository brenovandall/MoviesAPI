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
    // using the context db class -- > 
    private DataMovieContext _context;
    // using auto mapper -- >
    private IMapper _mapper;
    // ctor of context, then... need to use context props to reference data
    public MovieController(DataMovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // declaring the api method <get, post, ...>
    [HttpPost]
    public IActionResult AddMovieOnTheList(
        [FromBody] CreateMovieDto movieDto)
    {
        Movie movie = _mapper.Map<Movie>(movieDto);
        //Movie movie = new()
        //{
        //    Title = movieDto.Title,
        //    Genre = movieDto.Genre,
        //    Duration_min = movieDto.Duration_min
        //};
        // using function " [FromBody] " because the paramether will be declared to the body requisition fields -- >
        _context.Movies.Add(movie);
        _context.SaveChanges();

        // action that create the movie and returns the location of armazenated data -- >
        return CreatedAtAction(nameof(SortMoviesById), 
            new { id = movie.Id }, movie);
    }

    [HttpGet]
    public IEnumerable<ReadMovieDto> GetMoviesList() // return all movies that were send with post method
    {
        // in this case, using IEnumerable cause List has inheritance from this, so i can use IEnumarable for all classes that inherit the interface
        return _mapper.Map<List<ReadMovieDto>>(_context.Movies.ToList());
    }

    // declaring the api method <get, post, ...>
    //[HttpGet]
    //public IEnumerable<Movie> GetMoviesList([FromQuery] int skip = 0, [FromQuery] int take = 10) // return all movies that were send with post method
    //{
    //    // in this case, using IEnumerable cause List has inheritance from this, so i can use IEnumarable for all classes that inherit the interface
    //    return _context.Movies.Skip(skip).Take(take);
    //}


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

    // put -- > update any movie
    [HttpPut("{index}")]
    public IActionResult UpdateMovie(int index, [FromBody] UpdateMovieDto updatedDto)
    {
        var update = _context.Movies.FirstOrDefault(x => x.Id == index);
        // NotFound ==> 404 NotFound Error
        if (update == null) return NotFound();
        // updated movie dto to movie default class -- >
        _mapper.Map(updatedDto, update);
        _context.SaveChanges();
        // NoContent ==> 204 NoContent
        return NoContent();
    }

    [HttpDelete("{position}")]
    public IActionResult DeleteMovie(int position)
    {
        var movie = _context.Movies.FirstOrDefault(x => x.Id == position);
        // NotFound ==> 404 NotFound Error
        if (position == null) return NotFound();
        // remove the paramether position movie
        _context.Remove(movie);
        _context.SaveChanges();
        // NoContent ==> 204 NoContent
        return NoContent();
    }
}