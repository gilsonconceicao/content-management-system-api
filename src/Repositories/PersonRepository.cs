using AutoMapper;
using cmsapplication.src.Contexts;
using cmsapplication.src.Models.Read;
using cmsapplication.src.Repositories.Interfaces;

namespace cmsapplication.src.Repositories;

public class PersonRepository : IPersonRepository
{
    private DataBaseContext _context;
    private IMapper _mapper;
    public PersonRepository(DataBaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ICollection<PersonReadModel> GetAllPerson() 
    {
        var persons = _mapper.Map<ICollection<PersonReadModel>>(_context.persons.ToList()); 
        return persons;
    }
}
