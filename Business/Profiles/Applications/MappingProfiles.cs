using AutoMapper;
using Business.Requests.Applications;
using Business.Responses.Applications;
using Entities;

namespace Business.Profiles.Applications;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Application, CreateApplicationRequest>().ReverseMap();
        CreateMap<Application, UpdateApplicationRequest>().ReverseMap();
        CreateMap<Application, DeleteApplicationRequest>().ReverseMap();

        CreateMap<Application, CreateApplicationResponse>().ReverseMap();
        CreateMap<Application, UpdateApplicationResponse>().ReverseMap();
        CreateMap<Application, DeleteApplicationResponse>().ReverseMap();
        CreateMap<Application, GetAllApplicationResponse>().ReverseMap();
        CreateMap<Application, GetByIdApplicationResponse>().ReverseMap();
    }
}
