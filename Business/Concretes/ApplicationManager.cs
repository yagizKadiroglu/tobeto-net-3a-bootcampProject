using AutoMapper;
using Business.Abstracts;
using Business.Requests.Applications;
using Business.Responses.Applications;
using Business.Rules;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class ApplicationManager : IApplicationService
{
    private readonly IApplicationRepository _applicationRepository;
    private readonly IMapper _mapper;
    private readonly ApplicationBusinessRules _rules;

    public ApplicationManager(IApplicationRepository applicationRepository, IMapper mapper, ApplicationBusinessRules rules)
    {
        _applicationRepository = applicationRepository;
        _mapper = mapper;
        _rules = rules;
    }

    public async Task<IDataResult<CreateApplicationResponse>> AddAsync(CreateApplicationRequest request)
    {
        await _rules.BlackListCheck(request.ApplicantId);

        Application application = _mapper.Map<Application>(request);
        await _applicationRepository.AddAsync(application);

        CreateApplicationResponse response = _mapper.Map<CreateApplicationResponse>(application);
        return new SuccessDataResult<CreateApplicationResponse>(response);

    }

    public async Task<IDataResult<DeleteApplicationResponse>> DeleteAsync(DeleteApplicationRequest request)
    {
        var application = await _applicationRepository.GetAsync(a => a.Id == request.Id,
            include: x => x.Include(x => x.Applicant).Include(x => x.Bootcamp).Include(x => x.ApplicationState));

        await _applicationRepository.DeleteAsync(application);

        DeleteApplicationResponse deleteApplicationResponse = _mapper.Map<DeleteApplicationResponse>(application);
        return new SuccessDataResult<DeleteApplicationResponse>(deleteApplicationResponse);
    }

    public async Task<IDataResult<List<GetAllApplicationResponse>>> GetAllAsync()
    {
        List<Application> applications = await _applicationRepository.GetAllAsync(
            include:x=>x.Include(x=>x.Applicant).Include(x => x.Bootcamp).Include(x => x.ApplicationState));

        List<GetAllApplicationResponse> responses = _mapper.Map<List<GetAllApplicationResponse>>(applications);
        return new SuccessDataResult<List<GetAllApplicationResponse>>(responses);
    }

    public async Task<IDataResult<GetByIdApplicationResponse>> GetByIdAsync(int id)
    {
        var result = await _applicationRepository.GetAsync(a => a.Id == id);

        GetByIdApplicationResponse getByIdApplicationResponse = _mapper.Map<GetByIdApplicationResponse>(result);
        return new SuccessDataResult<GetByIdApplicationResponse>(getByIdApplicationResponse);
    }

    public async Task<IDataResult<UpdateApplicationResponse>> UpdateAsync(UpdateApplicationRequest request)
    {
        var result = await _applicationRepository.GetAsync(a => a.Id == request.Id);

        _mapper.Map(request, result);

        await _applicationRepository.UpdateAsync(result);

        UpdateApplicationResponse applicationResponse = _mapper.Map<UpdateApplicationResponse>(result);
        return new SuccessDataResult<UpdateApplicationResponse>(applicationResponse);
    }
}
