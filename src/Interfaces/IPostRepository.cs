using cmsapplication.src.Models;
using cmsapplication.src.Models.Create;
using cmsapplication.src.Models.Read;
using cmsapplication.src.Models.Update;

namespace cmsapplication.src.Interfaces
{
    public interface IPostRepository
    {
        ICollection<PostReadModel> GetAllPosts(
            int page = 0,
            int size = 5
        );
        PostReadModel GetPostById(Guid id);
        void Insert(PostCreateModel post);
        void Update(Guid id, PostUpdateModel post);
        void Delete(Post post);
        void Save();
    }
}
