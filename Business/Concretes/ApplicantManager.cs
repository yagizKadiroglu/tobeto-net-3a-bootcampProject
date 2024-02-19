using Business.Abstracts;
using Business.Requests.Applicants;
using Business.Responses.Applicants;
using DataAccess.Abstracts;
using Entities;

namespace Business.Concretes;

public class ApplicantManager : IApplicantService
{
    private readonly IApplicantRepository _applicantRepository;

    public ApplicantManager(IApplicantRepository applicantRepository)
    {
        _applicantRepository = applicantRepository;
    }

    public async Task<CreateApplicantResponse> AddAsync(CreateApplicantRequest request)
    {
        Applicant applicant = new();
        applicant.Username = request.Username;
        applicant.FirstName = request.FirstName;
        applicant.LastName = request.LastName;
        applicant.DateOfBirth = request.DateOfBirth;
        applicant.NationalIdentity = request.NationalIdentity;
        applicant.Email = request.Email;
        applicant.Password = request.Password;
        applicant.About = request.About;

        await _applicantRepository.AddAsync(applicant);

        CreateApplicantResponse applicantResponse = new();
        applicantResponse.Username = applicant.Username;
        applicantResponse.FirstName = applicant.FirstName;
        applicantResponse.LastName = applicant.LastName;
        applicantResponse.DateOfBirth = applicant.DateOfBirth;
        applicantResponse.NationalIdentity = applicant.NationalIdentity;
        applicantResponse.Email = applicant.Email;
        applicantResponse.Password = applicant.Password;
        applicantResponse.About = applicant.About;
        applicantResponse.CreatedDate = applicant.CreatedDate;

        return applicantResponse;

    }

    public async Task<DeleteApplicantResponse> DeleteAsync(DeleteApplicantRequest request)
    {
       var applicant = await _applicantRepository.GetAsync(a => a.Id == request.Id);

        await _applicantRepository.DeleteAsync(applicant);
        
        DeleteApplicantResponse deleteApplicantResponse = new();
        deleteApplicantResponse.Username = applicant.Username;
        deleteApplicantResponse.DeletedDate = applicant.DeletedDate;


        return deleteApplicantResponse;
    }

    public async Task<List<GetAllApplicantResponse>> GetAllAsync()
    {
        List<GetAllApplicantResponse> applicantResponses = new();
        foreach (var item in await _applicantRepository.GetAllAsync())
        {
            GetAllApplicantResponse result = new();
            result.Id = item.Id;
            result.Username = item.Username;
            result.FirstName = item.FirstName;
            result.LastName = item.LastName;
            result.DateOfBirth = item.DateOfBirth;
            result.NationalIdentity = item.NationalIdentity;
            result.Email = item.Email;
            result.Password = item.Password;
            result.About = item.About;
            applicantResponses.Add(result);
        }
        return applicantResponses;


    }

    public async Task<GetByIdApplicantResponse> GetByIdAsync(int id)
    {
        var result = await _applicantRepository.GetAsync(a => a.Id == id);

        GetByIdApplicantResponse getByIdApplicantResponse = new();
        getByIdApplicantResponse.Id = result.Id;
        getByIdApplicantResponse.Username = result.Username;
        getByIdApplicantResponse.FirstName = result.FirstName;
        getByIdApplicantResponse.LastName = result.LastName;
        getByIdApplicantResponse.DateOfBirth = result.DateOfBirth;
        getByIdApplicantResponse.NationalIdentity = result.NationalIdentity;
        getByIdApplicantResponse.Email = result.Email;
        getByIdApplicantResponse.Password = result.Password;
        getByIdApplicantResponse.About = result.About;

        return getByIdApplicantResponse;
    }

    public async Task<UpdateApplicantResponse> UpdateAsync(UpdateApplicantRequest request)
    {
        var result = await _applicantRepository.GetAsync(a => a.Id == request.Id);
        result.Id = request.Id;
        result.Username = request.Username;
        result.FirstName = request.FirstName;
        result.LastName = request.LastName;
        result.DateOfBirth = request.DateOfBirth;
        result.NationalIdentity = request.NationalIdentity;
        result.Email = request.Email;
        result.Password = request.Password;
        result.About = request.About;

        await _applicantRepository.UpdateAsync(result);

        UpdateApplicantResponse applicantResponse = new();
        applicantResponse.Username = result.Username;
        applicantResponse.FirstName = result.FirstName;
        applicantResponse.LastName = result.LastName;
        applicantResponse.DateOfBirth = result.DateOfBirth;
        applicantResponse.NationalIdentity = result.NationalIdentity;
        applicantResponse.Email = result.Email;
        applicantResponse.Password = result.Password;
        applicantResponse.About = result.About;
        applicantResponse.UpdatedDate = result.UpdatedDate;

        return applicantResponse;
    }
}
