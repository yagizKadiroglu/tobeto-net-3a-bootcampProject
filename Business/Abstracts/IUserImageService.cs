using Business.Requests.UserImages;
using Business.Responses.UserImages;
using Core.Utilities.Results;

namespace Business.Abstracts;

public interface IUserImageService
{
    Task<IDataResult<CreateUserImageResponse>> AddAsync(CreateUserImageRequest request);
    Task<IDataResult<DeleteUserImageResponse>> DeleteAsync(DeleteUserImageRequest request);
    Task<IDataResult<UpdateUserImageResponse>> UpdateAsync(UpdateUserImageRequest request);
    Task<IDataResult<List<GetAllUserImageResponse>>> GetAllAsync();
    Task<IDataResult<GetByIdUserImageResponse>> GetByIdAsync(int id);

}
