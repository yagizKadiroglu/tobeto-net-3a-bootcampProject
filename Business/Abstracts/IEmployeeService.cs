using Business.Requests.Employees;
using Business.Responses.Employees;
using Core.Utilities.Results;

namespace Business.Abstracts;

public interface IEmployeeService
{
    Task<IDataResult<CreateEmployeeResponse>> AddAsync(CreateEmployeeRequest request);
    Task<IDataResult<DeleteEmployeeResponse>> DeleteAsync(DeleteEmployeeRequest request);
    Task<IDataResult<UpdateEmployeeResponse>> UpdateAsync(UpdateEmployeeRequest request);
    Task<IDataResult<List<GetAllEmployeeResponse>>> GetAllAsync();
    Task<IDataResult<GetByIdEmployeeResponse>> GetByIdAsync(int id);

}
