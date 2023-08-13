using AutoMapper;
using cmsapplication.src.Contexts;
using cmsapplication.src.Models.Create;
using cmsapplication.src.Models.Update;
using cmsapplication.src.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace cmsapplication.src.Controllers;
[ApiController]
[Route("[Controller]")]
public class PostsController : Controller
{
    private PostRepository _postRepository;
    private IMapper _mapper;

    public PostsController(DataBaseContext context, IMapper mapper)
    {
        _postRepository = new PostRepository(context, mapper);
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAllPosts ([FromQuery] int page = 0, [FromQuery] int size = 5)
    {
        var posts = _postRepository.GetAllPosts(page, size);
        if (posts == null)
        {
            return BadRequest("Erro ao obter os posts");
        }
        return Ok(posts);
    }

    [HttpGet("{Id}")]
    public IActionResult UpdatePost(Guid id)
    {
        var updateById = _postRepository.GetPostById(id);
        if (updateById == null)
        {
            return NotFound("Post não existe");
        }
        return Ok(updateById);
    }

    [HttpPost]
    public IActionResult CreatePost (PostCreateModel post)
    {
        if (post == null)
        {
            return BadRequest("Erro ao criar o post"); 
        } 
        _postRepository.Insert(post);
        _postRepository.Save();
        return Ok(post);
    }

    [HttpPut("{Id}")]
    public IActionResult UpdatePost(Guid id, [FromBody] UpdatePostModel post)
    {
        var updateById = _postRepository.GetPostById(id);
        if (updateById == null)
        {
            return NotFound("Post não existe");
        }

        if (post == null)
        {
            return BadRequest("Erro ao criar o post"); 
        }

        _postRepository.Update(id, post);
        _postRepository.Save();
        return Ok(post);
    }
}
