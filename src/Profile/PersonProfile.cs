using AutoMapper;
using cmsapplication.src.Models;
using cmsapplication.src.Models.Create;
using cmsapplication.src.Models.Read;
using cmsapplication.src.Models.Update;

namespace TaskLIst_API.src.Profiles;

public class PersonProfile : Profile
{
    public PersonProfile() 
    { 
        CreateMap<Person, PersonReadModel>(); 
        CreateMap<PersonCreateModel, Person>(); 
        CreateMap<PersonUpdateModel, Person>(); 
    }
}