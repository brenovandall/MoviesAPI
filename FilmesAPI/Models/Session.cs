using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Session
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "You need to specify ")]
    public int RoomCapacity { get; set; }
    public int MovieId { get; set; }
    public virtual Movie Movie { get; set; }
    public int? CineId { get; set; }
    public virtual Cine Cine { get; set; }
}
