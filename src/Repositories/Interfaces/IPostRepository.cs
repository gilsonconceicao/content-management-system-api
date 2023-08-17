﻿using cmsapplication.src.Models;
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
        List<RelatedPersonReadModel> GetPostByPersonId(Guid personId);
        PostReadModel GetPostById(Guid id);    
        void Insert(PostCreateModel post, Person person); 
        void Update(Guid id, PostUpdateModel post); 
        void Delete(Post post);
        void Save();
    } 
}
