using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Cine
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "The field needs to be completed")]
    [MaxLength(45)]
    public string Name { get; set; }
}
