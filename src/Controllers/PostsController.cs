using AutoMapper;
using cmsapplication.src.Contexts;
using cmsapplication.src.Models;
using cmsapplication.src.Models.Create;
using cmsapplication.src.Models.Read;
using cmsapplication.src.Models.Update;
using cmsapplication.src.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace cmsapplication.src.Controllers;
[ApiController]
[Route("[Controller]")]
public class PostsController : Controller
{
    private PostRepository _postRepository;
    private UserRepository _userRepository;
    private IMapper _mapper;

    public PostsController(DataBaseContext context, IMapper mapper)
    {
        _postRepository = new PostRepository(context, mapper);
        _userRepository = new UserRepository(context, mapper);
        _mapper = mapper;
    }

    /// <summary>
    /// Retorna todos os posts cadastrados
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<PostReadModel>))]
    public IActionResult GetAllPosts ([FromQuery] int page = 0, [FromQuery] int size = 5)
    {
        var posts = _postRepository.GetAllPosts(page, size);
        if (posts is null)
        {
            return BadRequest("Erro ao obter os posts");
        }
        return Ok(posts);
    }

    /// <summary>
    /// Retorna um usuário específico
    /// </summary>
    [HttpGet("{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PostReadModel))]
    public IActionResult GetPostById(Guid Id)  
    {  
        var relatedPosts = _postRepository.GetPostById(Id);
        if (relatedPosts is null)
        {
            return NotFound(new { error = "Post não existe" });
        }
        return Ok(relatedPosts);  
    }

    /// <summary>
    /// Cria uma nova publicação por pessoa
    /// </summary>
    [HttpPost("/Post/{UserId}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreatePost (Guid UserId, PostCreateModel post)
    {
        User user = await _userRepository.GetUserById(UserId);

        if (user is null)
        {
            return NotFound("Pessoa não existe"); 
        }
        if (post is null)
        {
            return BadRequest("Erro ao criar o post"); 
        }

        await _postRepository.Insert(post, user);
        await _postRepository.Save(); 
        return Ok(post);
    }

    /// <summary>
    /// Cria uma nova publicação por pessoa
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult UpdatePost(Guid id, [FromBody] PostUpdateModel post)
    {
        var updateById = _postRepository.GetPostById(id);
        if (updateById is null)
        {
            return NotFound(new { error = "Post não existe" });
        }

        if (post is null)
        {
            return BadRequest("Erro ao criar o post"); 
        }

        _postRepository.Update(id, post);
        _postRepository.Save();
        return Ok(post);
    }

    /// <summary>
    /// Remove um post da base de dados
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult DeletePostById (Guid id)
    {
        Post post = _mapper.Map<Post>(_postRepository.GetPostById(id));
        if (post is null)
        {
            return NotFound(new { error = "Post não existe" });
        }
        try
        {
            _postRepository.Delete(post);
            return Ok(); 
        }
        catch (Exception ex)
        {
            return BadRequest(new 
            {
                error = ex.Message,
                message = "Erro inesperado ao remover um post " + post.Title
            });
        }
    }
}
