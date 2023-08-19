using AutoMapper;
using cmsapplication.src.Contexts;
using cmsapplication.src.Models.Create;
using cmsapplication.src.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace cmsapplication.src.Controllers;
[Route("[Controller]")]
[ApiController]
public class AuthController : Controller
{
    private AuthRepository _authRepository;
    
    private IMapper _mapper;

    public AuthController(DataBaseContext context, IMapper mapper, IConfiguration configuration)
    { 
        _authRepository = new AuthRepository(context, mapper, configuration);
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult Login([FromBody] AuthCreateModel user)
    {
        AuthCreateModel findPerson = _authRepository.GetPersonByEmailAndPassword(user); 
        if (findPerson != null)
        { 
            var token = _authRepository.Login(findPerson); 
            return Ok( new { token });
        }
        else
        {
            return BadRequest(new { error = "Usuário não encontrado" });
        }
    }
}
