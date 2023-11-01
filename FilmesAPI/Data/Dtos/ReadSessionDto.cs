using FilmesAPI.Models;

namespace FilmesAPI.Data.Dtos;

public class ReadSessionDto
{
    public int RoomCapacity { get; set; }
    public int MovieId { get; set; }
    public int CineId { get; set; }
}
