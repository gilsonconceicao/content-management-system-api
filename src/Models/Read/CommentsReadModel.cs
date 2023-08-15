namespace cmsapplication.src.Models.Read;

public class CommentsReadModel
{
    public Guid PostId { get; set; }
    public string Comment { get; set; } 
    public DateTime DateTime { get; set; }
}
