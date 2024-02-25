using AutoMapper;
using Business.Abstracts;
using Business.Requests.UserImages;
using Business.Responses.UserImages;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities;

namespace Business.Concretes;

public class UserImageManager : IUserImageService
{
    private readonly IUserImageRepository _userImageRepository;
    private readonly IMapper _mapper;

    public UserImageManager(IUserImageRepository userImageRepository, IMapper mapper)
    {
        _userImageRepository = userImageRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<CreateUserImageResponse>> AddAsync(CreateUserImageRequest request)
    {
        UserImage userImage = _mapper.Map<UserImage>(request);
        await _userImageRepository.AddAsync(userImage);

        CreateUserImageResponse response = _mapper.Map<CreateUserImageResponse>(userImage);
        return new SuccessDataResult<CreateUserImageResponse>(response);

    }

    public async Task<IDataResult<DeleteUserImageResponse>> DeleteAsync(DeleteUserImageRequest request)
    {
        var userImage = await _userImageRepository.GetAsync(a => a.Id == request.Id);

        await _userImageRepository.DeleteAsync(userImage);

        DeleteUserImageResponse deleteUserImageResponse = _mapper.Map<DeleteUserImageResponse>(userImage);
        return new SuccessDataResult<DeleteUserImageResponse>(deleteUserImageResponse);
    }

    public async Task<IDataResult<List<GetAllUserImageResponse>>> GetAllAsync()
    {
        List<UserImage> userImages = await _userImageRepository.GetAllAsync();

        List<GetAllUserImageResponse> responses = _mapper.Map<List<GetAllUserImageResponse>>(userImages);
        return new SuccessDataResult<List<GetAllUserImageResponse>>(responses);
    }

    public async Task<IDataResult<GetByIdUserImageResponse>> GetByIdAsync(int id)
    {
        var result = await _userImageRepository.GetAsync(a => a.Id == id);

        GetByIdUserImageResponse getByIdUserImageResponse = _mapper.Map<GetByIdUserImageResponse>(result);
        return new SuccessDataResult<GetByIdUserImageResponse>(getByIdUserImageResponse);
    }

    public async Task<IDataResult<UpdateUserImageResponse>> UpdateAsync(UpdateUserImageRequest request)
    {
        var result = await _userImageRepository.GetAsync(a => a.Id == request.Id);

        _mapper.Map(request, result);

        await _userImageRepository.UpdateAsync(result);

        UpdateUserImageResponse userImageResponse = _mapper.Map<UpdateUserImageResponse>(result);
        return new SuccessDataResult<UpdateUserImageResponse>(userImageResponse);
    }
}
