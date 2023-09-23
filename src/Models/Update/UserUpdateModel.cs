using System.ComponentModel.DataAnnotations;

namespace cmsapplication.src.Models.Update;
public class UserUpdateModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}
