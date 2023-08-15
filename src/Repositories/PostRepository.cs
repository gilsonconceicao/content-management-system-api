﻿using AutoMapper;
using cmsapplication.src.Contexts;
using cmsapplication.src.Models;
using cmsapplication.src.Models.Create;
using cmsapplication.src.Models.Read;
using cmsapplication.src.Models.Update;
using cmsapplication.src.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace cmsapplication.src.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly DataBaseContext _context;
        private PersonRepository _personRepository; 
        private IMapper _mapper;

        public PostRepository(DataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _personRepository = new PersonRepository(context, mapper);
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

        public ICollection<PostReadModel> GetPostById (Guid personId) 
        {
            var postById = _mapper.Map<PersonReadModel>(
                 _context
                .persons
                .FirstOrDefault(post => post.Id == personId)! 
            ); 
            return postById.RelatedPosts;
        }
        public void Insert(PostCreateModel post)
        {
            var newPost = _mapper.Map<Post>(post);
            newPost.Id = Guid.NewGuid();
            _context.posts.Add(newPost);
        }
        public void Update(Guid id, PostUpdateModel post) 
        {
            var updated = GetPostById(id); 
            var updatedData = _mapper.Map<Post>(updated);
            _context.posts.Entry(updatedData).CurrentValues.SetValues(post);
            _context.Entry(updated).State = EntityState.Modified; 
        }
        public void Delete(Guid id) 
        {
            _context.posts.FirstOrDefault(post => post.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
