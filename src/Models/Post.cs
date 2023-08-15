namespace cmsapplication.src.Models; 

public class Post 
{ 
    public Guid Id { get; set; } 
    public Person Person { get; set; } 
    public Guid PersonId { get; set; }
    public string Title { get; set; } 
    public string Description { get; set; }  
    public bool HideLikesNumber { get; set; } = false; 
    public bool DisableComments { get; set; } = false; 
    public ICollection<Comments>? Comments { get; set; }
}