using Business.Requests.ApplicationStates;
using Business.Responses.ApplicationStates;
using Core.Utilities.Results;

namespace Business.Abstracts;

public interface IApplicationStateService
{
    Task<IDataResult<CreateApplicationStateResponse>> AddAsync(CreateApplicationStateRequest request);
    Task<IDataResult<DeleteApplicationStateResponse>> DeleteAsync(DeleteApplicationStateRequest request);
    Task<IDataResult<UpdateApplicationStateResponse>> UpdateAsync(UpdateApplicationStateRequest request);
    Task<IDataResult<List<GetAllApplicationStateResponse>>> GetAllAsync();
    Task<IDataResult<GetByIdApplicationStateResponse>> GetByIdAsync(int id);

}
