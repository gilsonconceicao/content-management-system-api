using System.ComponentModel.DataAnnotations;

namespace cmsapplication.src.Models.Create;

public class PostCreateModel
{
    [Required] 
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    public string Biography { get; set; }
    public ICollection<CommentsCreateModel>? Comments { get; set; }
    public bool HideLikesNumber { get; set; } = false;
    public bool DisableComments { get; set; } = false;
}
