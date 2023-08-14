using cmsapplication.src.Models.Create;
using System.ComponentModel.DataAnnotations;

namespace cmsapplication.src.Models.Update;
public class PostUpdateModel
{
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    public ICollection<CommentsCreateModel>? comments { get; set; }
    public bool hideLikesNumber { get; set; } = false;
    public bool disableComments { get; set; } = false;
}
