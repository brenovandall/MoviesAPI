
// fields to test the api -- >

//"Street": "7 de Setembro Street",
//"Number": "344",
//"City": "Blumenau",
//"State": "Santa Catarina",
//"PostalCode": "9090990",
//"Country": "Brazil"




using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos;

public class CreateAddressDto
{
    [Required(ErrorMessage = "Street address needs to be completed")]
    [StringLength(150)]
    public string Street { get; set; }
    [Required(ErrorMessage = "Number needs to be specified")]
    public int Number { get; set; }
    [Required(ErrorMessage = "City needs to be sprecified")]
    [StringLength(150)]
    public string City { get; set; }
    [Required(ErrorMessage = "State field needs to be completed")]
    [StringLength(50)]
    public string State { get; set; }
    [Required(ErrorMessage = "PostalCode needs to be specified")]
    [StringLength(12)]
    public string PostalCode { get; set; }
    [Required(ErrorMessage = "Country needs to be specified")]
    [StringLength(50)]
    public string Country { get; set; }
}
