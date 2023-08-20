using AutoMapper;
using cmsapplication.src.Contexts;
using cmsapplication.src.Models;
using cmsapplication.src.Models.Create;
using cmsapplication.src.Models.Read;
using cmsapplication.src.Models.Update;
using cmsapplication.src.Repositories;
using cmsapplication.src.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cmsapplication.src.Controllers;
[Route("[Controller]")]
[ApiController]
public class CommentController : Controller
{
    private CommentsRepository _commentRepository;
    private PostRepository _postRepository; 
    private IMapper _mapper;

    public CommentController(DataBaseContext context, IMapper mapper)
    {
        _commentRepository = new CommentsRepository(context, mapper);
        _postRepository = new PostRepository(context, mapper);
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public IActionResult GetCommentByPostId(Guid id)
    {
        var comment = _commentRepository.GetCommentById(id);
        if (comment == null)
        {
            return NotFound(new { error = "Comentário não encontrado" }); 
        }
        return Ok(comment);
    }

    [HttpPost("{postId}")]
    public IActionResult CreateComment(Guid postId, CommentsCreateModel comment)
    {
        var post = _postRepository.GetPostById(postId);
        if (post == null)
        {
            return NotFound(new { error = "Post não encontrado" }); 
        }
        _commentRepository.Insert(_mapper.Map<PostReadModel, Post>(post), comment);
        _commentRepository.Save();
        return Ok(comment);
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePost(Guid id, CommentUpdateModel comment)
    {
        var commentById = _commentRepository.GetCommentById(id);
        if (commentById == null)
        {
            return NotFound(new { error = "Comentário não existe" });
        }
        _commentRepository.Update(commentById.Id, comment);
        _commentRepository.Save();
        return Ok();
    }
}
