using cmsapplication.src.Models.Read;

namespace cmsapplication.src.Repositories.Interfaces;

public interface IPersonRepository 
{
    ICollection<PersonReadModel> GetAllPerson(); 
}

