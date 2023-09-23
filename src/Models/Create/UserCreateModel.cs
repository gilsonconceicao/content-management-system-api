using System.ComponentModel.DataAnnotations;

namespace cmsapplication.src.Models.Create;

public class UserCreateModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public string UserName { get; set; }
    public string PhoneNumber { get; set; }
}
