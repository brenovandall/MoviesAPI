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
    private static List<Movie> movies = new List<Movie>();
    private static int index = 0;

    // declaring the api method <get, post, ...>
    [HttpPost]
    public IActionResult AddMovieOnTheList([FromBody] Movie movie)
    {
        movie.Id = index++;
        // using function " [FromBody] " because the paramether will be declared to the body requisition fields -- >
        movies.Add(movie);
        //Console.WriteLine(movie.Id);
        //Console.WriteLine(movie.Title);
        //Console.WriteLine(movie.Genre);
        //Console.WriteLine(movie.Duration_min);
        // action that create the movie and returns the location of armazenated data -- >
        return CreatedAtAction(nameof(SortMoviesById), new { id = movie.Id }, movie);
    }

    // declaring the api method <get, post, ...>
    [HttpGet]
    public IEnumerable<Movie> GetMoviesList([FromQuery] int skip = 0, [FromQuery] int take = 10) // return all movies that were send with post method
    {
        // in this case, using IEnumerable cause List has inheritance from this, so i can use IEnumarable for all classes that inherit the interface
        return movies.Skip(skip).Take(take);
    }


    [HttpGet("{id}")]
    public IActionResult SortMoviesById(int id)
    {
        // IActionResult because the interface returns the action that was executed
        var moviesVar = movies.FirstOrDefault(m => m.Id == id);
        // NotFound ==> 404 NotFound Error
        if (moviesVar == null) return NotFound();
        // OK ==> 200 Ok Success
        return Ok(moviesVar);
    }

}
