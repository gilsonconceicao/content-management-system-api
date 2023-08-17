using cmsapplication.src.Models.Create;
using System.ComponentModel.DataAnnotations;

namespace cmsapplication.src.Models.Read;

public class PostReadModel
{
    public Guid Id { get; set; }  
    public PersonReadModel Person { get; set; }
    public Guid PersonId { get; set; }
    public string Biography { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }  
    public ICollection<CommentsReadModel>? Comments { get; set; }
    public bool HideLikesNumber { get; set; }
    public bool DisableComments { get; set; } 
}
