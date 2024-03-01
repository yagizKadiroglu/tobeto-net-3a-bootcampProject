using AutoMapper;
using Business.Abstracts;
using Business.Requests.BlackLists;
using Business.Responses.BlackLists;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class BlackListManager : IBlackListService
{
    private readonly IBlackListRepository _blackListRepository;
    private readonly IMapper _mapper;

    public BlackListManager(IBlackListRepository blackListRepository, IMapper mapper)
    {
        _blackListRepository = blackListRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<CreateBlackListResponse>> AddAsync(CreateBlackListRequest request)
    {
        BlackList blackList = _mapper.Map<BlackList>(request);
        await _blackListRepository.AddAsync(blackList);

        CreateBlackListResponse response = _mapper.Map<CreateBlackListResponse>(blackList);
        return new SuccessDataResult<CreateBlackListResponse>(response);

    }

    public async Task<IDataResult<DeleteBlackListResponse>> DeleteAsync(DeleteBlackListRequest request)
    {
        var blackList = await _blackListRepository.GetAsync(a => a.Id == request.Id,
            include: x => x.Include(x => x.Applicant));

        await _blackListRepository.DeleteAsync(blackList);

        DeleteBlackListResponse deleteBlackListResponse = _mapper.Map<DeleteBlackListResponse>(blackList);
        return new SuccessDataResult<DeleteBlackListResponse>(deleteBlackListResponse);
    }

    public async Task<IDataResult<List<GetAllBlackListResponse>>> GetAllAsync()
    {
        List<BlackList> blackLists = await _blackListRepository.GetAllAsync(
            include: x => x.Include(x => x.Applicant));

        List<GetAllBlackListResponse> responses = _mapper.Map<List<GetAllBlackListResponse>>(blackLists);
        return new SuccessDataResult<List<GetAllBlackListResponse>>(responses);
    }

    public async Task<IDataResult<GetByIdBlackListResponse>> GetByApplicantIdAsync(int id)
    {
        var result = await _blackListRepository.GetAsync(a => a.ApplicantId == id);

        GetByIdBlackListResponse getByIdBlackListResponse = _mapper.Map<GetByIdBlackListResponse>(result);
        return new SuccessDataResult<GetByIdBlackListResponse>(getByIdBlackListResponse);
    }

    public async Task<IDataResult<GetByIdBlackListResponse>> GetByIdAsync(int id)
    {
        var result = await _blackListRepository.GetAsync(a => a.Id == id);

        GetByIdBlackListResponse getByIdBlackListResponse = _mapper.Map<GetByIdBlackListResponse>(result);
        return new SuccessDataResult<GetByIdBlackListResponse>(getByIdBlackListResponse);
    }

    public async Task<IDataResult<UpdateBlackListResponse>> UpdateAsync(UpdateBlackListRequest request)
    {
        var result = await _blackListRepository.GetAsync(a => a.Id == request.Id);

        _mapper.Map(request, result);

        await _blackListRepository.UpdateAsync(result);

        UpdateBlackListResponse blackListResponse = _mapper.Map<UpdateBlackListResponse>(result);
        return new SuccessDataResult<UpdateBlackListResponse>(blackListResponse);
    }
}
