using AutoMapper;
using cmsapplication.src.Contexts;
using cmsapplication.src.Models;
using cmsapplication.src.Models.Create;
using cmsapplication.src.Models.Read;
using cmsapplication.src.Models.Update;
using cmsapplication.src.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace cmsapplication.src.Controllers;
[Route("[Controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private UserRepository _userRepository;
    private IMapper _mapper;

    public UserController(DataBaseContext context, IMapper mapper)
    {
        _userRepository = new UserRepository(context, mapper);
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um novo usuário na base de dados
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserCreateModel))]
    public async Task<IActionResult> CreateNewUser(UserCreateModel user)
    {
        var newUser = await _userRepository.CreateNewUser(user);
        var doesExist = await _userRepository.DoesEmailOrUsernameExist(user.Email, user.UserName); 

        if (doesExist)
        {
            return BadRequest( new {message = "Nome de usuário ou email já existem"} );
        }

        await _userRepository.SaveChangesAsync();
        return Ok(newUser); 
    }

    /// <summary>
    /// Atualiza os dados de um usuário existente
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateUser(Guid id, UserUpdateModel user)
    {
        User userToUpdate = await _userRepository.GetUserById(id);
        if (userToUpdate is null)
        {
            return NotFound(new { message = "Usuário não encontrado" });
        }
        _userRepository.UpdateUserById(userToUpdate, user); 
        await _userRepository.SaveChangesAsync();
        return Ok();
    }

    /// <summary>
    /// Remove um usuário da base de dados
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteUserById(Guid id)
    {
        User user = await _userRepository.GetUserById(id);
        if (user is null)
        {
            return NotFound(new { message = "Usuário não encontrado" });
        }
        _userRepository.DeleteUserById(user);
        await _userRepository.SaveChangesAsync();
        return Ok();
    }

    /// <summary>
    /// Retorna todos os usuários cadastrados
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserReadModel>))]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userRepository.GetAllUsers();
        return Ok(users);
    }

}
