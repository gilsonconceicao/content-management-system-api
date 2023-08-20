using AutoMapper;
using cmsapplication.src.Models;
using cmsapplication.src.Models.Create;
using cmsapplication.src.Models.Read;

namespace TaskLIst_API.src.Profiles;

public class CommentProfile : Profile
{
    public CommentProfile()
    {
        CreateMap<CommentsCreateModel, Comments>()
            .ReverseMap();
        CreateMap<Comments, CommentsReadModel>()
            .ReverseMap();
    }
}