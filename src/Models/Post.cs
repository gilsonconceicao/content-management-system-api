namespace cmsapplication.src.Models; 

public class Post 
{ 
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }    
    public User User { get; set; }
    public string Title { get; set; }  
    public string Description { get; set; }  
    public bool HideLikesNumber { get; set; } = false; 
    public bool DisableComments { get; set; } = false; 
    public IList<Comments>? Comments { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.Now;
}