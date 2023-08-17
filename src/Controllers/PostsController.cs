﻿using AutoMapper;
using cmsapplication.src.Contexts;
using cmsapplication.src.Models;
using cmsapplication.src.Models.Create;
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
        if (posts is null)
        {
            return BadRequest("Erro ao obter os posts");
        }
        return Ok(posts);
    }

    [HttpGet("{Id}")]
    public IActionResult GetPostById(Guid Id)  
    {  
        var relatedPosts = _postRepository.GetPostById(Id);
        if (relatedPosts is null)
        {
            return NotFound(new { error = "Post não existe" });
        }
        return Ok(relatedPosts);  
    }

    [HttpPost("/Post/{PersonId}")]
    public IActionResult CreatePost (Guid PersonId, PostCreateModel post)
    {
        Person person = _personRepository.GetPersonById(PersonId);
        if (person is null)
        {
            return NotFound("Pessoa não existe"); 
        }
        if (post is null)
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

    [HttpDelete("{Id}")]
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
                message = "Erro inesperado ao remover a pessoaperson " + post.Title
            });
        }
    }
}
