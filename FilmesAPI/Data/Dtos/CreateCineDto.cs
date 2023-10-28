using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos;

public class CreateCineDto
{
    [Required(ErrorMessage = "The field needs to be completed")]
    [MaxLength(45)]
    public string Name { get; set; }
    public int AddressId { get; set; }
}
