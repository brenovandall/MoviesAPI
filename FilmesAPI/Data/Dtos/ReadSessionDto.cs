using FilmesAPI.Models;

namespace FilmesAPI.Data.Dtos;

public class ReadSessionDto
{
    public int RoomCapacity { get; set; }
    public ReadMovieDto Movie { get; set; }
    public ReadCineDto Cine { get; set; }
}
