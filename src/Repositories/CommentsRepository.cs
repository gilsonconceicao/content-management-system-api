using AutoMapper;
using cmsapplication.src.Contexts;
using cmsapplication.src.Models;
using cmsapplication.src.Models.Create;
using cmsapplication.src.Models.Read;
using cmsapplication.src.Models.Update;
using cmsapplication.src.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace cmsapplication.src.Repositories;

public class CommentsRepository : ICommentRepository
{
    private DataBaseContext _context;
    private PostRepository _postRepository; 
    private IMapper _mapper;

    public CommentsRepository(DataBaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
        _postRepository = new PostRepository(context, mapper);
    }

    public CommentsReadModel GetCommentById(Guid id)
    {
        var comment = _context.comments.FirstOrDefault(comment => 
            comment.Id == id
        );
        return _mapper.Map<Comments, CommentsReadModel>(comment!);
    }

    public void Insert(Post post, CommentsCreateModel comment)
    {
        var commentMapper = _mapper.Map<Comments>(comment); 
        commentMapper.Id = Guid.NewGuid();
        commentMapper.PostId = post.Id; 
        post.Comments!.Add(commentMapper);
        _context.comments.Add(commentMapper);
    }

    public void Update(Guid id, CommentUpdateModel comment)
    {
        var commentById = _context.comments.FirstOrDefault(c => c.Id == id);
        _context.comments.Entry(commentById!).CurrentValues.SetValues(comment);
        _context.Entry(commentById!).State = EntityState.Modified;
    }

    public void Save() 
    { 
        _context.SaveChanges();
    }
}
