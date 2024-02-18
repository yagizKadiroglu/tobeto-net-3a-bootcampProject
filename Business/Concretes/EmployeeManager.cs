using Business.Abstracts;
using Business.Requests.Employees;
using Business.Responses.Employees;
using DataAccess.Abstracts;
using Entities;

namespace Business.Concretes;

public class EmployeeManager : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeManager(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public CreateEmployeeResponse Add(CreateEmployeeRequest request)
    {
        Employee employee = new();
        employee.Username = request.Username;
        employee.FirstName = request.FirstName;
        employee.LastName = request.LastName;
        employee.DateOfBirth = request.DateOfBirth;
        employee.NationalIdentity = request.NationalIdentity;
        employee.Email = request.Email;
        employee.Password = request.Password;
        employee.Position = request.Position;

        _employeeRepository.Add(employee);

        CreateEmployeeResponse employeeResponse = new();
        employeeResponse.Username = employee.Username;
        employeeResponse.FirstName = employee.FirstName;
        employeeResponse.LastName = employee.LastName;
        employeeResponse.DateOfBirth = employee.DateOfBirth;
        employeeResponse.NationalIdentity = employee.NationalIdentity;
        employeeResponse.Email = employee.Email;
        employeeResponse.Password = employee.Password;
        employeeResponse.Position = employee.Position;
        employeeResponse.CreatedDate = employee.CreatedDate;

        return employeeResponse;

    }

    public DeleteEmployeeResponse Delete(DeleteEmployeeRequest request)
    {
        var employee = _employeeRepository.Get(a => a.Id == request.Id);

        _employeeRepository.Delete(employee);

        DeleteEmployeeResponse deleteEmployeeResponse = new();
        deleteEmployeeResponse.Username = employee.Username;
        deleteEmployeeResponse.DeletedDate = employee.DeletedDate;


        return deleteEmployeeResponse;
    }

    public List<GetAllEmployeeResponse> GetAll()
    {
        List<GetAllEmployeeResponse> employeeResponses = new();
        foreach (var item in _employeeRepository.GetAll())
        {
            GetAllEmployeeResponse result = new();
            result.Id = item.Id;
            result.Username = item.Username;
            result.FirstName = item.FirstName;
            result.LastName = item.LastName;
            result.DateOfBirth = item.DateOfBirth;
            result.NationalIdentity = item.NationalIdentity;
            result.Email = item.Email;
            result.Password = item.Password;
            result.Position = item.Position;
            employeeResponses.Add(result);
        }
        return employeeResponses;


    }

    public GetByIdEmployeeResponse GetById(int id)
    {
        var result = _employeeRepository.Get(a => a.Id == id);

        GetByIdEmployeeResponse getByIdEmployeeResponse = new();
        getByIdEmployeeResponse.Id = result.Id;
        getByIdEmployeeResponse.Username = result.Username;
        getByIdEmployeeResponse.FirstName = result.FirstName;
        getByIdEmployeeResponse.LastName = result.LastName;
        getByIdEmployeeResponse.DateOfBirth = result.DateOfBirth;
        getByIdEmployeeResponse.NationalIdentity = result.NationalIdentity;
        getByIdEmployeeResponse.Email = result.Email;
        getByIdEmployeeResponse.Password = result.Password;
        getByIdEmployeeResponse.Position = result.Position;

        return getByIdEmployeeResponse;
    }

    public UpdateEmployeeResponse Update(UpdateEmployeeRequest request)
    {
        var result = _employeeRepository.Get(a => a.Id == request.Id);
        result.Id = request.Id;
        result.Username = request.Username;
        result.FirstName = request.FirstName;
        result.LastName = request.LastName;
        result.DateOfBirth = request.DateOfBirth;
        result.NationalIdentity = request.NationalIdentity;
        result.Email = request.Email;
        result.Password = request.Password;
        result.Position = request.Position;

        _employeeRepository.Update(result);

        UpdateEmployeeResponse employeeResponse = new();
        employeeResponse.Username = result.Username;
        employeeResponse.FirstName = result.FirstName;
        employeeResponse.LastName = result.LastName;
        employeeResponse.DateOfBirth = result.DateOfBirth;
        employeeResponse.NationalIdentity = result.NationalIdentity;
        employeeResponse.Email = result.Email;
        employeeResponse.Password = result.Password;
        employeeResponse.Position = result.Position;
        employeeResponse.UpdatedDate = result.UpdatedDate;

        return employeeResponse;
    }
}
