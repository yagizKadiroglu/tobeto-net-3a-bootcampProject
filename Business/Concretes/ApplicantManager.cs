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

    public CreateApplicantResponse Add(CreateApplicantRequest request)
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

        _applicantRepository.Add(applicant);

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

    public DeleteApplicantResponse Delete(DeleteApplicantRequest request)
    {
       var applicant = _applicantRepository.Get(a => a.Id == request.Id);

        _applicantRepository.Delete(applicant);
        
        DeleteApplicantResponse deleteApplicantResponse = new();
        deleteApplicantResponse.Username = applicant.Username;
        deleteApplicantResponse.DeletedDate = applicant.DeletedDate;


        return deleteApplicantResponse;
    }

    public List<GetAllApplicantResponse> GetAll()
    {
        List<GetAllApplicantResponse> applicantResponses = new();
        foreach (var item in _applicantRepository.GetAll())
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

    public GetByIdApplicantResponse GetById(int id)
    {
        var result =_applicantRepository.Get(a => a.Id == id);

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

    public UpdateApplicantResponse Update(UpdateApplicantRequest request)
    {
        var result = _applicantRepository.Get(a => a.Id == request.Id);
        result.Id = request.Id;
        result.Username = request.Username;
        result.FirstName = request.FirstName;
        result.LastName = request.LastName;
        result.DateOfBirth = request.DateOfBirth;
        result.NationalIdentity = request.NationalIdentity;
        result.Email = request.Email;
        result.Password = request.Password;
        result.About = request.About;

        _applicantRepository.Update(result);

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
