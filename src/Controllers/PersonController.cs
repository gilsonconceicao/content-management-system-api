using AutoMapper;
using cmsapplication.src.Contexts;
using cmsapplication.src.Models.Create;
using cmsapplication.src.Models.Read;
using cmsapplication.src.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace cmsapplication.src.Controllers;
[Route("[Controller]")]
[ApiController]
public class PersonController : Controller
{
    private PersonRepository _personRepository;

    public PersonController(DataBaseContext context, IMapper mapper)
    {
        _personRepository = new PersonRepository(context, mapper);
    }

    [HttpGet]
    public IActionResult GetAllPersons()
    {
        ICollection<PersonReadModel> persons = _personRepository.GetAllPerson(); 
        if (persons == null)
        {
            return BadRequest("Erro ao obter informações de pessoas");
        }

        return Ok(persons);
    }

    [HttpPost]
    public IActionResult CreatePerson(PersonCreateModel person)
    {
        if (person == null) 
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
}
