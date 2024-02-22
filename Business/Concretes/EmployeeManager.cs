using AutoMapper;
using Business.Abstracts;
using Business.Requests.Employees;
using Business.Responses.Employees;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities;

namespace Business.Concretes;

public class EmployeeManager : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public EmployeeManager(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<CreateEmployeeResponse>> AddAsync(CreateEmployeeRequest request)
    {
        Employee employee = _mapper.Map<Employee>(request);
        await _employeeRepository.AddAsync(employee);

        CreateEmployeeResponse response = _mapper.Map<CreateEmployeeResponse>(employee);
        return new SuccessDataResult<CreateEmployeeResponse>(response);

    }

    public async Task<IDataResult<DeleteEmployeeResponse>> DeleteAsync(DeleteEmployeeRequest request)
    {
        var employee = await _employeeRepository.GetAsync(a => a.Id == request.Id);

        await _employeeRepository.DeleteAsync(employee);

        DeleteEmployeeResponse deleteEmployeeResponse = _mapper.Map<DeleteEmployeeResponse>(employee);
        return new SuccessDataResult<DeleteEmployeeResponse>(deleteEmployeeResponse);
    }

    public async Task<IDataResult<List<GetAllEmployeeResponse>>> GetAllAsync()
    {
        List<Employee> employees = await _employeeRepository.GetAllAsync();

        List<GetAllEmployeeResponse> responses = _mapper.Map<List<GetAllEmployeeResponse>>(employees);
        return new SuccessDataResult<List<GetAllEmployeeResponse>>(responses);
    }

    public async Task<IDataResult<GetByIdEmployeeResponse>> GetByIdAsync(int id)
    {
        var result = await _employeeRepository.GetAsync(a => a.Id == id);

        GetByIdEmployeeResponse getByIdEmployeeResponse = _mapper.Map<GetByIdEmployeeResponse>(result);
        return new SuccessDataResult<GetByIdEmployeeResponse>(getByIdEmployeeResponse);
    }

    public async Task<IDataResult<UpdateEmployeeResponse>> UpdateAsync(UpdateEmployeeRequest request)
    {
        var result = await _employeeRepository.GetAsync(a => a.Id == request.Id);

        _mapper.Map(request, result);

        await _employeeRepository.UpdateAsync(result);

        UpdateEmployeeResponse employeeResponse = _mapper.Map<UpdateEmployeeResponse>(result);
        return new SuccessDataResult<UpdateEmployeeResponse>(employeeResponse);
    }
}
