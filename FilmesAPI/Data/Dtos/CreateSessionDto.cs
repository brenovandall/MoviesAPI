namespace FilmesAPI.Data.Dtos;

public class CreateSessionDto
{
    public int RoomCapacity { get; set; }
    public int MovieId { get; set; }
    public int CineId { get; set; }
}
