using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Session
{
    public int RoomCapacity { get; set; }
    public int? MovieId { get; set; }
    public virtual Movie Movie { get; set; }
    public int? CineId { get; set; }
    public virtual Cine Cine { get; set; }
}
