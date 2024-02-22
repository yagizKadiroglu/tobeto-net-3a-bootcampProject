using AutoMapper;
using Business.Abstracts;
using Business.Requests.BootcampStates;
using Business.Responses.BootcampStates;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities;

namespace Business.Concretes;

public class BootcampStateManager : IBootcampStateService
{
    private readonly IBootcampStateRepository _bootcampStateRepository;
    private readonly IMapper _mapper;

    public BootcampStateManager(IBootcampStateRepository bootcampStateRepository, IMapper mapper)
    {
        _bootcampStateRepository = bootcampStateRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<CreateBootcampStateResponse>> AddAsync(CreateBootcampStateRequest request)
    {
        BootcampState bootcampState = _mapper.Map<BootcampState>(request);
        await _bootcampStateRepository.AddAsync(bootcampState);

        CreateBootcampStateResponse response = _mapper.Map<CreateBootcampStateResponse>(bootcampState);
        return new SuccessDataResult<CreateBootcampStateResponse>(response);

    }

    public async Task<IDataResult<DeleteBootcampStateResponse>> DeleteAsync(DeleteBootcampStateRequest request)
    {
        var bootcampState = await _bootcampStateRepository.GetAsync(a => a.Id == request.Id);

        await _bootcampStateRepository.DeleteAsync(bootcampState);

        DeleteBootcampStateResponse deleteBootcampStateResponse = _mapper.Map<DeleteBootcampStateResponse>(bootcampState);
        return new SuccessDataResult<DeleteBootcampStateResponse>(deleteBootcampStateResponse);
    }

    public async Task<IDataResult<List<GetAllBootcampStateResponse>>> GetAllAsync()
    {
        List<BootcampState> bootcampStates = await _bootcampStateRepository.GetAllAsync();

        List<GetAllBootcampStateResponse> responses = _mapper.Map<List<GetAllBootcampStateResponse>>(bootcampStates);
        return new SuccessDataResult<List<GetAllBootcampStateResponse>>(responses);
    }

    public async Task<IDataResult<GetByIdBootcampStateResponse>> GetByIdAsync(int id)
    {
        var result = await _bootcampStateRepository.GetAsync(a => a.Id == id);

        GetByIdBootcampStateResponse getByIdBootcampStateResponse = _mapper.Map<GetByIdBootcampStateResponse>(result);
        return new SuccessDataResult<GetByIdBootcampStateResponse>(getByIdBootcampStateResponse);
    }

    public async Task<IDataResult<UpdateBootcampStateResponse>> UpdateAsync(UpdateBootcampStateRequest request)
    {
        var result = await _bootcampStateRepository.GetAsync(a => a.Id == request.Id);

        _mapper.Map(request, result);

        await _bootcampStateRepository.UpdateAsync(result);

        UpdateBootcampStateResponse bootcampStateResponse = _mapper.Map<UpdateBootcampStateResponse>(result);
        return new SuccessDataResult<UpdateBootcampStateResponse>(bootcampStateResponse);
    }
}
