using cmsapplication.src.Models.Read;

namespace cmsapplication.src.Models.Update;

public class PersonUpdateModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; } 
    public List<PostUpdateModel> RelatedPosts { get; set; }
}
