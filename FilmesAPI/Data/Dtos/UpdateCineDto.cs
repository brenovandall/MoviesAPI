using System.ComponentModel.DataAnnotations;

namespace FislmesAPI.Data.Dtos;

public class UpdateCineDto
{
    [Required(ErrorMessage = "The field needs to be completed")]
    [MaxLength(45)]
    public string Name { get; set; }
}
