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
    List<Movie> movies = new List<Movie>();

    // declaring the api method <get, post, ...>
    [HttpPost]
    public void AddMovieOnTheList([FromBody] Movie movie)
    {
        // using function " [FromBody] " because the paramether will be declared to the body requisition fields -- >
        movies.Add(movie);
    }
}
