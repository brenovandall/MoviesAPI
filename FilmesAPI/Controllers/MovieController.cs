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
    private int index = 0;

    // declaring the api method <get, post, ...>
    [HttpPost]
    public void AddMovieOnTheList([FromBody] Movie movie)
    {
        movie.Id = index++;
        // using function " [FromBody] " because the paramether will be declared to the body requisition fields -- >
        movies.Add(movie);

    }

    // declaring the api method <get, post, ...>
    [HttpGet]
    public IEnumerable<Movie> GetMoviesList() // return all movies that were send with post method
    {
        // in this case, using IEnumerable cause List has inheritance from this, so i can use IEnumarable for all classes that inherit the interface
        return movies;
    }



    public void SortMoviesById(int id)
    {
        // using linq to do a conditional that sort movie by the id informated in get method, the id is the paramether of this method
        movies.FirstOrDefault(movies => movies.Id == id);
    }

}
