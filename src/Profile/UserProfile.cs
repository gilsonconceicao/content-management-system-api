using AutoMapper;
using cmsapplication.src.Models;
using cmsapplication.src.Models.Create;
using cmsapplication.src.Models.Read;
using cmsapplication.src.Models.Update;

namespace TaskLIst_API.src.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserReadModel>();
        CreateMap<UserCreateModel, User>();
        CreateMap<UserUpdateModel, User>();
    }
}