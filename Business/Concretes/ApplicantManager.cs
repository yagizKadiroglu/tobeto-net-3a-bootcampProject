using AutoMapper;
using Business.Abstracts;
using Business.Constants;
using Business.Requests.Applicants;
using Business.Responses.Applicants;
using Business.Rules;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Exceptions.Types;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities;

namespace Business.Concretes;

public class ApplicantManager : IApplicantService
{
    private readonly IApplicantRepository _applicantRepository;
    private readonly IMapper _mapper;
    private readonly ApllicantBusinessRules _rules;

    public ApplicantManager(IApplicantRepository applicantRepository, IMapper mapper, ApllicantBusinessRules rules)
    {
        _applicantRepository = applicantRepository;
        _mapper = mapper;
        _rules = rules;
    }

    public async Task<IDataResult<CreateApplicantResponse>> AddAsync(CreateApplicantRequest request)
    {

        await _rules.IsApplicantExist(request.Username,request.NationalIdentity,request.Email);

        Applicant applicant = _mapper.Map<Applicant>(request);
        await _applicantRepository.AddAsync(applicant);

        CreateApplicantResponse response = _mapper.Map<CreateApplicantResponse>(applicant);
        return new SuccessDataResult<CreateApplicantResponse>(response,ApplicantMessage.ApplicantAdded);

    }

    public async Task<IDataResult<DeleteApplicantResponse>> DeleteAsync(DeleteApplicantRequest request)
    {
       await _rules.IsDeletedCheck(request.Id);

       var applicant = await _applicantRepository.GetAsync(a => a.Id == request.Id);

        await _applicantRepository.DeleteAsync(applicant);

        DeleteApplicantResponse deleteApplicantResponse = _mapper.Map<DeleteApplicantResponse>(applicant);
        return new SuccessDataResult<DeleteApplicantResponse>(deleteApplicantResponse);
    }

    [LogAspect(typeof(MssqlLogger))]
    public async Task<IDataResult<List<GetAllApplicantResponse>>> GetAllAsync()
    {
        List<Applicant> applicants = await _applicantRepository.GetAllAsync();

        List<GetAllApplicantResponse> responses = _mapper.Map<List<GetAllApplicantResponse>>(applicants);
        return new SuccessDataResult<List<GetAllApplicantResponse>>(responses);
    }

    public async Task<IDataResult<GetByIdApplicantResponse>> GetByIdAsync(int id)
    {
        var result = await _applicantRepository.GetAsync(a => a.Id == id);

        GetByIdApplicantResponse getByIdApplicantResponse = _mapper.Map<GetByIdApplicantResponse>(result);
        return new SuccessDataResult<GetByIdApplicantResponse>(getByIdApplicantResponse);
    }

    public async Task<IDataResult<UpdateApplicantResponse>> UpdateAsync(UpdateApplicantRequest request)
    {
        await _rules.IsApplicantExist(request.Username, request.NationalIdentity, request.Email);


        var result = await _applicantRepository.GetAsync(a => a.Id == request.Id);

        _mapper.Map(request, result);

        await _applicantRepository.UpdateAsync(result);

        UpdateApplicantResponse applicantResponse = _mapper.Map<UpdateApplicantResponse>(result);
        return new SuccessDataResult<UpdateApplicantResponse>(applicantResponse);
    }
}
