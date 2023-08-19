using AutoMapper;
using cmsapplication.src.Models;
using cmsapplication.src.Models.Create;
using cmsapplication.src.Models.Read;

namespace TaskLIst_API.src.Profiles;

public class AuthProfile : Profile
{
    public AuthProfile()
    { 
        CreateMap<Person, AuthReadModel>();
        CreateMap<AuthCreateModel, AuthReadModel>()
            .ReverseMap();
        CreateMap<AuthCreateModel, Person>()
            .ReverseMap(); 
    }
}