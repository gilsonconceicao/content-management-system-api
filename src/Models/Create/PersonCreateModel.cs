namespace cmsapplication.src.Models.Create;

public class PersonCreateModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime BirthDate { get; set; }
    public ICollection<PostCreateModel> relatedPosts { get; set; } 
}
