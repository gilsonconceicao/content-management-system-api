using AutoMapper;
using cmsapplication.src.Contexts;
using cmsapplication.src.Interfaces;
using cmsapplication.src.Models;
using cmsapplication.src.Models.Create;
using cmsapplication.src.Models.Read;
using cmsapplication.src.Models.Update;
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

    public Comments GetCommentById(Guid id)
    {
        var comment = _context.comments.FirstOrDefault(comment => 
            comment.Id == id
        );
        return comment;
    }

    public async Task Insert(Post post, CommentsCreateModel comment)
    {
        Comments commentMapper = _mapper.Map<Comments>(comment);
        commentMapper.PostId = post.Id; 
        post.Comments!.Add(commentMapper);
        await _context.comments.AddAsync(commentMapper);
    }

    public void Update(Comments commentById, CommentUpdateModel comment)
    {
        _context.comments.Entry(commentById!).CurrentValues.SetValues(comment);
        _context.Entry(commentById!).State = EntityState.Modified;
    }

    public async Task Save() 
    { 
        await _context.SaveChangesAsync();
    }
}
