using AutoMapper;
using cmsapplication.src.Contexts;
using cmsapplication.src.Models;
using cmsapplication.src.Models.Create;
using cmsapplication.src.Models.Read;
using cmsapplication.src.Models.Update;
using cmsapplication.src.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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

    public Person GetPersonById(Guid id)
    {
        return _context.persons.FirstOrDefault(person => person.Id == id)!; 
    }

    public void Insert(PersonCreateModel person)
    { 
        var newPerson = _mapper.Map<Person>(person);
        newPerson.Id = Guid.NewGuid();
        _context.persons.Add(newPerson);
    }

    public void Update(Guid id, PersonUpdateModel post)
    {
        var updated = GetPersonById(id);
        var updatedData = _mapper.Map<Post>(updated);
        _context.posts.Entry(updatedData).CurrentValues.SetValues(post);
        _context.Entry(updated).State = EntityState.Modified;
    }
    public void Delete(Guid id)
    {
        _context.posts.FirstOrDefault(post => post.Id == id);
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}
