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
public class PersonController : Controller
{
    private PersonRepository _personRepository;
    private AuthRepository _authRepository; 
    private IMapper _mapper; 

    public PersonController(DataBaseContext context, IMapper mapper, IConfiguration configuration)
    {
        _personRepository = new PersonRepository(context, mapper);
        _authRepository = new AuthRepository(context, mapper, configuration);
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAllPersons()
    {
        ICollection<PersonReadModel> persons = _personRepository.GetAllPerson(); 
        if (persons is null)
        {
            return BadRequest("Erro ao obter informações de pessoas");
        }

        return Ok(persons);
    }

    [HttpGet("{Id}")]
    public IActionResult GetPersonById(Guid Id)
    {
        Person person = _personRepository.GetPersonById(Id);
        if (person is null)
        {
            return NotFound("Pessoa não existe");
        }
         
        return Ok(_mapper.Map<PersonReadModel>(person));
    }

    [HttpPost]
    public IActionResult CreatePerson(PersonCreateModel person)
    {
        var existUser = _authRepository.CheckUserExists(person.Email); 
        if (existUser)
        {
            return BadRequest(new { error = "Email informado já existe" });
        }

        if (person is null) 
        {
            return BadRequest("Erro ao cadastrar pessoa"); 
        }

        try
        {
            _personRepository.Insert(person);
            _personRepository.Save();
            return Ok(person);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePost(Guid id, [FromBody] PersonUpdateModel person)
    { 
        var findPerson = _personRepository.GetPersonById(id);
        if (findPerson is null)
        {
            return NotFound("Usuário não existe"); 
        }

        try
        {
            _personRepository.Update(findPerson, person);
            _personRepository.Save();
            return Ok();
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    public IActionResult Delete(Guid id)
    {
        Person person = _personRepository.GetPersonById(id);
        if (person is null)
        {
            return NotFound(new { error = "Pessoa não encontrada"}); 
        }
        try
        {
            _personRepository.Delete(person);
            _personRepository.Save();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                error = ex.Message, 
                message = "Erro inesperado ao remover a pessoaperson " + person.Name
            });
        }
    }
}
