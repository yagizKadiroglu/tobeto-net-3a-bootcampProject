using Business.Requests.Bootcamps;
using Business.Responses.Bootcamps;
using Core.Utilities.Results;

namespace Business.Abstracts;

public interface IBootcampService
{
    Task<IDataResult<CreateBootcampResponse>> AddAsync(CreateBootcampRequest request);
    Task<IDataResult<DeleteBootcampResponse>> DeleteAsync(DeleteBootcampRequest request);
    Task<IDataResult<UpdateBootcampResponse>> UpdateAsync(UpdateBootcampRequest request);
    Task<IDataResult<List<GetAllBootcampResponse>>> GetAllAsync();
    Task<IDataResult<GetByIdBootcampResponse>> GetByIdAsync(int id);

}
