using Business.Requests.Employees;
using Business.Responses.Employees;

namespace Business.Abstracts;

public interface IEmployeeService
{
    Task<CreateEmployeeResponse> AddAsync(CreateEmployeeRequest request);
    Task<DeleteEmployeeResponse> DeleteAsync(DeleteEmployeeRequest request);
    Task<UpdateEmployeeResponse> UpdateAsync(UpdateEmployeeRequest request);
    Task<List<GetAllEmployeeResponse>> GetAllAsync();
    Task<GetByIdEmployeeResponse> GetByIdAsync(int id);

}
