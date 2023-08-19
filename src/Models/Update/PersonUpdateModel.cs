using cmsapplication.src.Models.Read;
using System.ComponentModel.DataAnnotations;

namespace cmsapplication.src.Models.Update;

public class PersonUpdateModel
{
    [Required]
    public string Name { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; } 
}
