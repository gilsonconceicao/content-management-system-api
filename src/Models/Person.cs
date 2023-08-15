using cmsapplication.src.Models.Read;

namespace cmsapplication.src.Models;

public class Person
{ 
    public Guid Id {get; set;}  
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; } 
    public ICollection<Post> RelatedPosts { get; set; } 
}
