using System.ComponentModel.DataAnnotations;
namespace cmsapplication.src.Models.Create;

public class PersonCreateModel
{
    [Required]
    public string Name { get; set; }
    [Required]
    [DataType(DataType.Password)] 
    public string Password { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime BirthDate { get; set; }
}