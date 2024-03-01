using Business.Requests.BlackLists;
using Business.Responses.BlackLists;
using Core.Utilities.Results;

namespace Business.Abstracts;

public interface IBlackListService
{
    Task<IDataResult<CreateBlackListResponse>> AddAsync(CreateBlackListRequest request);
    Task<IDataResult<DeleteBlackListResponse>> DeleteAsync(DeleteBlackListRequest request);
    Task<IDataResult<UpdateBlackListResponse>> UpdateAsync(UpdateBlackListRequest request);
    Task<IDataResult<List<GetAllBlackListResponse>>> GetAllAsync();
    Task<IDataResult<GetByIdBlackListResponse>> GetByIdAsync(int id);
    Task<IDataResult<GetByIdBlackListResponse>> GetByApplicantIdAsync(int id);

}
