using Business.Requests.Applicants;
using Business.Responses.Applicants;
using Core.Utilities.Results;

namespace Business.Abstracts;

public interface IApplicantService
{
    Task<IDataResult<CreateApplicantResponse>> AddAsync(CreateApplicantRequest request);
    Task<IDataResult<DeleteApplicantResponse>> DeleteAsync(DeleteApplicantRequest request);
    Task<IDataResult<UpdateApplicantResponse>> UpdateAsync(UpdateApplicantRequest request);
    Task<IDataResult<List<GetAllApplicantResponse>>> GetAllAsync();
    Task<IDataResult<GetByIdApplicantResponse>> GetByIdAsync(int id);

}
