namespace cmsapplication.src.Models;

public class Comments
{
    public Guid PostId { get; set; }
    public string Comment { get; set; }
    public DateTime DateTime { get; set; }
    public Post Post { get; set; }
}
