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
    public async Task<IActionResult> CreateNewUser([FromBody] UserCreateModel user)
    {
        var newUser = await _userRepository.CreateNewUser(user);
        var doesExist = await _userRepository.DoesEmailOrUsernameExist(user.Email, user.UserName); 

        if (doesExist == true)
        {
            return BadRequest( new {message = "Nome de usuário ou email já existem"} );
        }

        try
        {
            await _userRepository.SaveChangesAsync();
            return Ok(newUser);
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                errorMessage = $"Erro ao criar o usuário",
                exception = ex.Message
            });
        }
    }

    /// <summary>
    /// Atualiza os dados de um usuário existente
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserUpdateModel user)
    {
        User userToUpdate = await _userRepository.GetUserById(id);
        if (userToUpdate is null)
        {
            return NotFound(new { message = "Usuário não encontrado" });
        }
        try
        {
            _userRepository.UpdateUserById(userToUpdate, user); 
            await _userRepository.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new 
            {
                errorMessage = $"Erro ao atualizar o usuário {id}", 
                exception = ex.Message
            });  
        }
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

        try
        {
            _userRepository.DeleteUserById(user);
            await _userRepository.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                errorMessage = $"Erro inesperado ao atualizar o {user.Name}",
                exception = ex.Message
            });
        }
    }

    /// <summary>
    /// Retorna todos os usuários cadastrados
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserReadModel>))]
    public async Task<IActionResult> GetAllUsers(
        [FromQuery] int page = 0, 
        [FromQuery] int size = 5
    )
    {
        try
        {
            var users = await _userRepository.GetAllUsers(page, size);
            return Ok(users);
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                errorMessage = $"Houve um erro ao consultar os dados dos usuários",
                exception = ex.Message
            });
        }
    }

}
