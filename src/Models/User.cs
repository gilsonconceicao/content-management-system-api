using System.ComponentModel.DataAnnotations;

namespace cmsapplication.src.Models;
public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Email { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public string UserName { get; set; }
    public string PhoneNumber { get; set; }
    public List<Post> RelatedPosts { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.Now;
}
