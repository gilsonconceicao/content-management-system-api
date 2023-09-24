using cmsapplication.src.Models.Create;
using cmsapplication.src.Models.Read;
using cmsapplication.src.Models.Update;
using cmsapplication.src.Models;

namespace cmsapplication.src.Interfaces;

public interface ICommentRepository
{
    Comments GetCommentById(Guid postId);
    Task Insert(Post post, CommentsCreateModel comment);
    void Update(Comments commentById, CommentUpdateModel comment);
    Task Save();
}

