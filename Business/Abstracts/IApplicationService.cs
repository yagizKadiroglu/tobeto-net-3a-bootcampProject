using Business.Requests.Applications;
using Business.Responses.Applications;
using Core.Utilities.Results;

namespace Business.Abstracts;

public interface IApplicationService
{
    Task<IDataResult<CreateApplicationResponse>> AddAsync(CreateApplicationRequest request);
    Task<IDataResult<DeleteApplicationResponse>> DeleteAsync(DeleteApplicationRequest request);
    Task<IDataResult<UpdateApplicationResponse>> UpdateAsync(UpdateApplicationRequest request);
    Task<IDataResult<List<GetAllApplicationResponse>>> GetAllAsync();
    Task<IDataResult<GetByIdApplicationResponse>> GetByIdAsync(int id);

}
