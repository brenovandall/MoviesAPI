using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    List<Movie> movies = new List<Movie>();

    [HttpPost]
    public void AddMovieOnTheList(Movie movie)
    {
        movies.Add(movie);
    }
}
