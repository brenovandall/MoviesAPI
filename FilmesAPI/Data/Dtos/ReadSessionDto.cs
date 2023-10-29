using FilmesAPI.Models;

namespace FilmesAPI.Data.Dtos;

public class ReadSessionDto
{
    public int RoomCapacity { get; set; }
    public virtual ReadMovieDto Movie { get; set; }
}
