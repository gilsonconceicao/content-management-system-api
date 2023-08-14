using AutoMapper;
using cmsapplication.src.Models;
using cmsapplication.src.Models.Create;
using cmsapplication.src.Models.Read;
using cmsapplication.src.Models.Update;

namespace TaskLIst_API.src.Profiles;

public class PostProfile : Profile
{ 
    public PostProfile()  
    {
        CreateMap<PostCreateModel, Post>()
            .ReverseMap();
        CreateMap<CommentsCreateModel, Comments>()
            .ReverseMap();
        CreateMap<Comments,CommentsReadModel>(); 
        CreateMap<Post, PostReadModel>();
        CreateMap<PostUpdateModel, Post>();
    }
}