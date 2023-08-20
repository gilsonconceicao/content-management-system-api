using AutoMapper;
using cmsapplication.src.Contexts;
using cmsapplication.src.Models;
using cmsapplication.src.Models.Create;
using cmsapplication.src.Repositories.Interfaces;

namespace cmsapplication.src.Repositories;

public class AuthRepository : IAuth
{
    //private PersonRepository _personRepository;
    private DataBaseContext _context;
    private TokenServices _tokenRepository;
    public IMapper _mapper;

    public AuthRepository(DataBaseContext context, IMapper mapper, IConfiguration configuration)
    {
        _context = context; 
        _mapper = mapper;
        _tokenRepository = new TokenServices(configuration);
    }

    public bool CheckUserExists(string email)
    {
        Person userExist = _context.persons.FirstOrDefault(person => 
            person.Email == email
        )!; 
        if (userExist != null)
        {
            return true;
        }
        return false;
    } 
     
    public AuthCreateModel GetPersonByEmailAndPassword(AuthCreateModel user)
    { 
        Person person = _context.persons.FirstOrDefault(person =>
            person.Email == user.Email && person.Password == user.Password
        )!; 
       
        return _mapper.Map<AuthCreateModel>( person );
    }

    public string Login(AuthCreateModel person) 
    {
        Person personUpdated = _mapper.Map<Person>(person);
        return _tokenRepository.GenerateToken(personUpdated); 
    }
}
