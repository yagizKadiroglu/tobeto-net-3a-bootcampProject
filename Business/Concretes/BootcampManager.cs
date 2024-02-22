using AutoMapper;
using Business.Abstracts;
using Business.Requests.Bootcamps;
using Business.Responses.Bootcamps;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class BootcampManager : IBootcampService
{
    private readonly IBootcampRepository _bootcampRepository;
    private readonly IMapper _mapper;

    public BootcampManager(IBootcampRepository bootcampRepository, IMapper mapper)
    {
        _bootcampRepository = bootcampRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<CreateBootcampResponse>> AddAsync(CreateBootcampRequest request)
    {
        Bootcamp bootcamp = _mapper.Map<Bootcamp>(request);
        await _bootcampRepository.AddAsync(bootcamp);

        CreateBootcampResponse response = _mapper.Map<CreateBootcampResponse>(bootcamp);
        return new SuccessDataResult<CreateBootcampResponse>(response);

    }

    public async Task<IDataResult<DeleteBootcampResponse>> DeleteAsync(DeleteBootcampRequest request)
    {
        var bootcamp = await _bootcampRepository.GetAsync(a => a.Id == request.Id,
            include: x => x.Include(x => x.Instructor).Include(x => x.BootcampState));

        await _bootcampRepository.DeleteAsync(bootcamp);

        DeleteBootcampResponse deleteBootcampResponse = _mapper.Map<DeleteBootcampResponse>(bootcamp);
        return new SuccessDataResult<DeleteBootcampResponse>(deleteBootcampResponse);
    }

    public async Task<IDataResult<List<GetAllBootcampResponse>>> GetAllAsync()
    {
        List<Bootcamp> bootcamps = await _bootcampRepository.GetAllAsync(
            include: x => x.Include(x => x.Instructor).Include(x => x.BootcampState));

        List<GetAllBootcampResponse> responses = _mapper.Map<List<GetAllBootcampResponse>>(bootcamps);
        return new SuccessDataResult<List<GetAllBootcampResponse>>(responses);
    }

    public async Task<IDataResult<GetByIdBootcampResponse>> GetByIdAsync(int id)
    {
        var result = await _bootcampRepository.GetAsync(a => a.Id == id);

        GetByIdBootcampResponse getByIdBootcampResponse = _mapper.Map<GetByIdBootcampResponse>(result);
        return new SuccessDataResult<GetByIdBootcampResponse>(getByIdBootcampResponse);
    }

    public async Task<IDataResult<UpdateBootcampResponse>> UpdateAsync(UpdateBootcampRequest request)
    {
        var result = await _bootcampRepository.GetAsync(a => a.Id == request.Id);

        _mapper.Map(request, result);

        await _bootcampRepository.UpdateAsync(result);

        UpdateBootcampResponse bootcampResponse = _mapper.Map<UpdateBootcampResponse>(result);
        return new SuccessDataResult<UpdateBootcampResponse>(bootcampResponse);
    }
}
