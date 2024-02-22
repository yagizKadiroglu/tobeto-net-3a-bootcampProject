using AutoMapper;
using Business.Abstracts;
using Business.Requests.ApplicationStates;
using Business.Responses.ApplicationStates;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities;

namespace Business.Concretes;

public class ApplicationStateManager : IApplicationStateService
{
    private readonly IApplicationStateRepository _applicationStateRepository;
    private readonly IMapper _mapper;

    public ApplicationStateManager(IApplicationStateRepository applicationStateRepository, IMapper mapper)
    {
        _applicationStateRepository = applicationStateRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<CreateApplicationStateResponse>> AddAsync(CreateApplicationStateRequest request)
    {
        ApplicationState applicationState = _mapper.Map<ApplicationState>(request);
        await _applicationStateRepository.AddAsync(applicationState);

        CreateApplicationStateResponse response = _mapper.Map<CreateApplicationStateResponse>(applicationState);
        return new SuccessDataResult<CreateApplicationStateResponse>(response);

    }

    public async Task<IDataResult<DeleteApplicationStateResponse>> DeleteAsync(DeleteApplicationStateRequest request)
    {
        var applicationState = await _applicationStateRepository.GetAsync(a => a.Id == request.Id);

        await _applicationStateRepository.DeleteAsync(applicationState);

        DeleteApplicationStateResponse deleteApplicationStateResponse = _mapper.Map<DeleteApplicationStateResponse>(applicationState);
        return new SuccessDataResult<DeleteApplicationStateResponse>(deleteApplicationStateResponse);
    }

    public async Task<IDataResult<List<GetAllApplicationStateResponse>>> GetAllAsync()
    {
        List<ApplicationState> applicationStates = await _applicationStateRepository.GetAllAsync();

        List<GetAllApplicationStateResponse> responses = _mapper.Map<List<GetAllApplicationStateResponse>>(applicationStates);
        return new SuccessDataResult<List<GetAllApplicationStateResponse>>(responses);
    }

    public async Task<IDataResult<GetByIdApplicationStateResponse>> GetByIdAsync(int id)
    {
        var result = await _applicationStateRepository.GetAsync(a => a.Id == id);

        GetByIdApplicationStateResponse getByIdApplicationStateResponse = _mapper.Map<GetByIdApplicationStateResponse>(result);
        return new SuccessDataResult<GetByIdApplicationStateResponse>(getByIdApplicationStateResponse);
    }

    public async Task<IDataResult<UpdateApplicationStateResponse>> UpdateAsync(UpdateApplicationStateRequest request)
    {
        var result = await _applicationStateRepository.GetAsync(a => a.Id == request.Id);

        _mapper.Map(request, result);

        await _applicationStateRepository.UpdateAsync(result);

        UpdateApplicationStateResponse applicationStateResponse = _mapper.Map<UpdateApplicationStateResponse>(result);
        return new SuccessDataResult<UpdateApplicationStateResponse>(applicationStateResponse);
    }
}
