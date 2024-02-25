using AutoMapper;
using Business.Requests.UserImages;
using Business.Responses.UserImages;
using Entities;

namespace Business.Profiles.UserImages;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<UserImage, CreateUserImageRequest>().ReverseMap();
        CreateMap<UserImage, UpdateUserImageRequest>().ReverseMap();
        CreateMap<UserImage, DeleteUserImageRequest>().ReverseMap();

        CreateMap<UserImage, CreateUserImageResponse>().ReverseMap();
        CreateMap<UserImage, UpdateUserImageResponse>().ReverseMap();
        CreateMap<UserImage, DeleteUserImageResponse>().ReverseMap();
        CreateMap<UserImage, GetAllUserImageResponse>().ReverseMap();
        CreateMap<UserImage, GetByIdUserImageResponse>().ReverseMap();
    }
}