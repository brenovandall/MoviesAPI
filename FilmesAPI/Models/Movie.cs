using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace FilmesAPI.Models;

public class Movie
{
    [Key] // key of database authentication
    [Required] // required, but automaticately recieves a value by auto_increment 
    public int Id { get; set; }

    // i can use conditionals at instances that i have in my class -- >
    // required string, if empty, the message error will appears -- >
    [Required(ErrorMessage = "You need to type the title of the movie")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "You need to type the genre of the movie")]
    // in this case, i can use conditional function that i can set a max string length -- >
    [MaxLength(15, ErrorMessage = "String characters exceeded")]
    public string? Genre { get; set; }

    [Required(ErrorMessage = "The duration of the movie needs to be informated")]
    // in this case, i can use conditional to the min and max range field -- >
    [Range(70, 250, ErrorMessage = "The duration exceeded the time limit")]
    public int Duration_min { get; set; }
    public virtual ICollection<Session> Sessions { get; set; }

}