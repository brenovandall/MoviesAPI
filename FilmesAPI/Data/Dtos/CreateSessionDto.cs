namespace FilmesAPI.Data.Dtos;

public class CreateSessionDto
{
    public int RoomCapacity { get; set; }
    public virtual int MovieId { get; set; }
    public virtual int CineId { get; set; }
}
