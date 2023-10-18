using System.Security.Cryptography.X509Certificates;

namespace FilmesAPI.Models;

public class Movie
{

    public string Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public int Duration_min { get; set; }

}
