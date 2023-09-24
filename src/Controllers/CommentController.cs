using AutoMapper;
using cmsapplication.src.Contexts;
using cmsapplication.src.Models;
using cmsapplication.src.Models.Create;
using cmsapplication.src.Models.Read;
using cmsapplication.src.Models.Update;
using cmsapplication.src.Repositories;
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

    /// <summary>
    /// Obtem informação de um comentário específico
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommentsReadModel))]
    public IActionResult GetCommentByPostId(Guid id)
    {
        var comment = _commentRepository.GetCommentById(id);
        if (comment == null)
        {
            return NotFound(new { error = "Comentário não encontrado" }); 
        }
        return Ok(comment);
    }

    /// <summary>
    /// Cria um comentário em um post já existente
    /// </summary>
    [HttpPost("{postId}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateComment(Guid postId, CommentsCreateModel comment)
    {
        var post = _postRepository.GetPostById(postId);
        if (post == null)
        {
            return NotFound(new { error = "Post não encontrado" }); 
        }

        try
        { 
            Post findPost = _mapper.Map<PostReadModel, Post>(post); 
            await _commentRepository.Insert(findPost, comment);
            await _commentRepository.Save();
            return Ok(comment);
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                message = "Erro ao criar um comentário",
                exception = ex.Message,
            }); 
        }
    }

    /// <summary>
    ///Atualiza um comentário
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult UpdatePost(Guid id, CommentUpdateModel comment)
    {
        var commentById = _commentRepository.GetCommentById(id);
        if (commentById == null)
        {
            return NotFound(new { message = "Comentário não existe" });
        }

        try
        {
            _commentRepository.Update(commentById, comment);
            _commentRepository.Save();
            return Ok(); 
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                message = "Erro ao atualizar um comentário",
                exception = ex.Message,
            });
        }
    }
}
