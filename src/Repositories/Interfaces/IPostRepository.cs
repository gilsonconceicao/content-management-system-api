using cmsapplication.src.Models;
using cmsapplication.src.Models.Create;
using cmsapplication.src.Models.Read;
using cmsapplication.src.Models.Update;

namespace cmsapplication.src.Repositories.Interfaces
{
    public interface IPostRepository
    {
        ICollection<PostReadModel> GetAllPosts(
            int page = 0, 
            int size = 5
        ); 
        ICollection<PostReadModel> GetPostById(Guid personId);
        void Insert(PostCreateModel post); 
        void Update(Guid id, PostUpdateModel post);
        void Delete(Guid postId);
        void Save();
    } 
}
