using AutoMapper;
using Business.Abstracts;
using Business.Requests.Instructors;
using Business.Responses.Instructors;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities;

namespace Business.Concretes;

public class InstructorManager : IInstructorService
{
    private readonly IInstructorRepository _instructorRepository;
    private readonly IMapper _mapper;

    public InstructorManager(IInstructorRepository instructorRepository, IMapper mapper)
    {
        _instructorRepository = instructorRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<CreateInstructorResponse>> AddAsync(CreateInstructorRequest request)
    {
        Instructor instructor = _mapper.Map<Instructor>(request);
        await _instructorRepository.AddAsync(instructor);

        CreateInstructorResponse response = _mapper.Map<CreateInstructorResponse>(instructor);
        return new SuccessDataResult<CreateInstructorResponse>(response);

    }

    public async Task<IDataResult<DeleteInstructorResponse>> DeleteAsync(DeleteInstructorRequest request)
    {
        var instructor = await _instructorRepository.GetAsync(a => a.Id == request.Id);

        await _instructorRepository.DeleteAsync(instructor);

        DeleteInstructorResponse deleteInstructorResponse = _mapper.Map<DeleteInstructorResponse>(instructor);
        return new SuccessDataResult<DeleteInstructorResponse>(deleteInstructorResponse);
    }

    public async Task<IDataResult<List<GetAllInstructorResponse>>> GetAllAsync()
    {
        List<Instructor> instructors = await _instructorRepository.GetAllAsync();

        List<GetAllInstructorResponse> responses = _mapper.Map<List<GetAllInstructorResponse>>(instructors);
        return new SuccessDataResult<List<GetAllInstructorResponse>>(responses);
    }

    public async Task<IDataResult<GetByIdInstructorResponse>> GetByIdAsync(int id)
    {
        var result = await _instructorRepository.GetAsync(a => a.Id == id);

        GetByIdInstructorResponse getByIdInstructorResponse = _mapper.Map<GetByIdInstructorResponse>(result);
        return new SuccessDataResult<GetByIdInstructorResponse>(getByIdInstructorResponse);
    }

    public async Task<IDataResult<UpdateInstructorResponse>> UpdateAsync(UpdateInstructorRequest request)
    {
        var result = await _instructorRepository.GetAsync(a => a.Id == request.Id);

        _mapper.Map(request, result);

        await _instructorRepository.UpdateAsync(result);

        UpdateInstructorResponse instructorResponse = _mapper.Map<UpdateInstructorResponse>(result);
        return new SuccessDataResult<UpdateInstructorResponse>(instructorResponse);
    }
}
