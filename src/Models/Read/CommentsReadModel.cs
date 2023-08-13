namespace cmsapplication.src.Models.Read;

public class CommentsReadModel
{
    public Guid PostId { get; set; }
    public string comment { get; set; }
    public DateTime DateTime { get; set; }
}
