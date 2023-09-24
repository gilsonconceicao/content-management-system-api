using cmsapplication.src.Models;
using cmsapplication.src.Models.Create;
using cmsapplication.src.Models.Read;
using cmsapplication.src.Models.Update;

namespace cmsapplication.src.Interfaces
{
    public interface IPostRepository
    {
        IList<PostReadModel> GetAllPosts(
            int page = 0,
            int size = 5
        );
        PostReadModel GetPostById(Guid id);
        Task Insert(PostCreateModel post, User user);
        void Update(Guid id, PostUpdateModel post);
        void Delete(Post post);
        Task Save();
    }
}
