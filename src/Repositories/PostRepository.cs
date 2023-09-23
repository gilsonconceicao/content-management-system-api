using AutoMapper;
using cmsapplication.src.Contexts;
using cmsapplication.src.Interfaces;
using cmsapplication.src.Models;
using cmsapplication.src.Models.Create;
using cmsapplication.src.Models.Read;
using cmsapplication.src.Models.Update;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cmsapplication.src.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly DataBaseContext _context;
        private IMapper _mapper;

        public PostRepository(DataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ICollection<PostReadModel> GetAllPosts([FromQuery] int page = 0, [FromQuery] int size = 5) 
        {
            var list = _mapper.Map<ICollection<PostReadModel>>(
                _context
                    .posts
                    .Include(post => post.Comments)
                    .Skip(page * size)
                    .Take(size)
                    .ToList()
            ); 
            return list;
        } 

       
        public PostReadModel GetPostById(Guid id)
        {
            return _mapper.Map<Post, PostReadModel>(
                _context
                .posts  
                .Include(post => post.Comments)
                .FirstOrDefault(post => post.Id == id)!
            );
        }
        public void Insert(PostCreateModel post)
        {
            var newPost = _mapper.Map<Post>(post);
            newPost.Id = Guid.NewGuid();
            //person.RelatedPosts.Add(newPost);
            _context.posts.Add(newPost); 
        }
        public void Update(Guid id, PostUpdateModel post) 
        { 
            var findPost = _context.posts.FirstOrDefault(post => post.Id == id); 
            var updatedData = _mapper.Map<Post>(findPost);
            _context.posts.Entry(updatedData).CurrentValues.SetValues(post);
            _context.Entry(findPost!).State = EntityState.Modified; 
        }
        public void Delete(Post post) 
        {
            _context.Remove(post);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
