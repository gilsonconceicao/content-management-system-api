namespace cmsapplication.src.Models; 

public class Post
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ICollection<Comments>? comments { get; set; }
    public bool hideLikesNumber { get; set; } = false; 
    public bool disableComments { get; set; } = false; 
}