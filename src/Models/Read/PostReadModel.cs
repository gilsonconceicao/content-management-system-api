using cmsapplication.src.Models.Create;
using System.ComponentModel.DataAnnotations;

namespace cmsapplication.src.Models.Read;

public class PostReadModel
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }  
    public IList<CommentsReadModel>? Comments { get; set; }
    public bool HideLikesNumber { get; set; }
    public bool DisableComments { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.Now;
}
