using cmsapplication.src.Models.Create;
using System.ComponentModel.DataAnnotations;

namespace cmsapplication.src.Models.Read;

public class PostReadModel
{
    public string Title { get; set; }
    public string Description { get; set; } 
    public ICollection<CommentsReadModel>? Comments { get; set; }
    public bool HideLikesNumber { get; set; }
    public bool DisableComments { get; set; } 
}
