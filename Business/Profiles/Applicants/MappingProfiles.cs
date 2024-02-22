using AutoMapper;
using Business.Requests.Applicants;
using Business.Responses.Applicants;
using Entities;

namespace Business.Profiles.Applicants;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Applicant, CreateApplicantRequest>().ReverseMap();
        CreateMap<Applicant, UpdateApplicantRequest>().ReverseMap();
        CreateMap<Applicant, DeleteApplicantRequest>().ReverseMap();

        CreateMap<Applicant, CreateApplicantResponse>().ReverseMap();
        CreateMap<Applicant, UpdateApplicantResponse>().ReverseMap();
        CreateMap<Applicant, DeleteApplicantResponse>().ReverseMap();
        CreateMap<Applicant, GetAllApplicantResponse>().ReverseMap();
        CreateMap<Applicant, GetByIdApplicantResponse>().ReverseMap();
    }
}
