using cmsapplication.src.Models.Create;
using System.ComponentModel.DataAnnotations;

namespace cmsapplication.src.Models.Read;

public class PostReadModel
{
    public string Title { get; set; }
    public string Description { get; set; } 
    public ICollection<CommentsReadModel>? comments { get; set; }
    public bool hideLikesNumber { get; set; }
    public bool disableComments { get; set; }
}
