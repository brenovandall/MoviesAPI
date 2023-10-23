using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos;

public class UpdateMovieDto
{
    [Required(ErrorMessage = "You need to type the title of the movie")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "You need to type the genre of the movie")]
    [StringLength(15, ErrorMessage = "String characters exceeded")]
    public string? Genre { get; set; }

    [Required(ErrorMessage = "The duration of the movie needs to be informated")]
    [Range(70, 250, ErrorMessage = "The duration exceeded the time limit")]
    public int Duration_min { get; set; }
}
