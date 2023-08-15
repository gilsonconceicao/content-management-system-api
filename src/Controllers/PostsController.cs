using AutoMapper;
using cmsapplication.src.Contexts;
using cmsapplication.src.Models;
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
    private PersonRepository _personRepository; 
    private IMapper _mapper;

    public PostsController(DataBaseContext context, IMapper mapper)
    {
        _postRepository = new PostRepository(context, mapper);
        _personRepository = new PersonRepository(context,mapper);
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

    [HttpGet("{PersonId}")]
    public IActionResult GetPostById(Guid personId) 
    { 
        var relatedPosts = _postRepository.GetPostById(personId);
        if (relatedPosts == null)
        {
            return NotFound("Pessoa não existe");
        }
        return Ok(relatedPosts);  
    }

    [HttpPost("/Post/{PersonId}")]
    public IActionResult CreatePost (Guid PersonId, PostCreateModel post)
    {
        Person person = _personRepository.GetPersonById(PersonId);
        if (person == null)
        {
            return NotFound("Pessoa não existe"); 
        }
        if (post == null)
        {
            return BadRequest("Erro ao criar o post"); 
        }
        _postRepository.Insert(post, person);
        _postRepository.Save(); 
        return Ok(post);
    }

    [HttpPut("{Id}")]
    public IActionResult UpdatePost(Guid id, [FromBody] PostUpdateModel post)
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
