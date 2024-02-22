using AutoMapper;
using Business.Requests.BootcampStates;
using Business.Responses.BootcampStates;
using Entities;

namespace Business.Profiles.BootcampStates;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<BootcampState, CreateBootcampStateRequest>().ReverseMap();
        CreateMap<BootcampState, UpdateBootcampStateRequest>().ReverseMap();
        CreateMap<BootcampState, DeleteBootcampStateRequest>().ReverseMap();

        CreateMap<BootcampState, CreateBootcampStateResponse>().ReverseMap();
        CreateMap<BootcampState, UpdateBootcampStateResponse>().ReverseMap();
        CreateMap<BootcampState, DeleteBootcampStateResponse>().ReverseMap();
        CreateMap<BootcampState, GetAllBootcampStateResponse>().ReverseMap();
        CreateMap<BootcampState, GetByIdBootcampStateResponse>().ReverseMap();
    }
}