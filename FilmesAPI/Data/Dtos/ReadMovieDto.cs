using FilmesAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos;

public class ReadMovieDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Genre { get; set; }
    public int Duration_min { get; set; }
    public ICollection<ReadSessionDto> Sessions { get; set; }
}
