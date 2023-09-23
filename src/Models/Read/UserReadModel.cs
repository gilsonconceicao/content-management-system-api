using System.ComponentModel.DataAnnotations;

namespace cmsapplication.src.Models.Read;

public class UserReadModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime CreateAt { get; set; }
}
