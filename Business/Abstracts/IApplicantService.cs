using Business.Requests.Applicants;
using Business.Responses.Applicants;

namespace Business.Abstracts;

public interface IApplicantService
{
    Task<CreateApplicantResponse> AddAsync(CreateApplicantRequest request);
    Task<DeleteApplicantResponse> DeleteAsync(DeleteApplicantRequest request);
    Task<UpdateApplicantResponse> UpdateAsync(UpdateApplicantRequest request);
    Task<List<GetAllApplicantResponse>> GetAllAsync();
    Task<GetByIdApplicantResponse> GetByIdAsync(int id);

}
