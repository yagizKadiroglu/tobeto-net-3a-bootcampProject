using AutoMapper;
using Business.Requests.Bootcamps;
using Business.Responses.Bootcamps;
using Entities;

namespace Business.Profiles.Bootcamps;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Bootcamp, CreateBootcampRequest>().ReverseMap();
        CreateMap<Bootcamp, UpdateBootcampRequest>().ReverseMap();
        CreateMap<Bootcamp, DeleteBootcampRequest>().ReverseMap();

        CreateMap<Bootcamp, CreateBootcampResponse>().ReverseMap();
        CreateMap<Bootcamp, UpdateBootcampResponse>().ReverseMap();
        CreateMap<Bootcamp, DeleteBootcampResponse>().ReverseMap();
        CreateMap<Bootcamp, GetAllBootcampResponse>().ReverseMap();
        CreateMap<Bootcamp, GetByIdBootcampResponse>().ReverseMap();
    }
}