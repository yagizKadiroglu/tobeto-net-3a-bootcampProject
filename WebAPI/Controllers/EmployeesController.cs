using Business.Abstracts;
using Business.Requests.Employees;
using Business.Responses.Employees;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IDataResult<CreateEmployeeResponse>> AddAsync(CreateEmployeeRequest request)
        {
            return await _employeeService.AddAsync(request);
        }

        [HttpPut]
        public async Task<IDataResult<UpdateEmployeeResponse>> UpdateAsync(UpdateEmployeeRequest request)
        {
            return await _employeeService.UpdateAsync(request);
        }

        [HttpDelete]
        public async Task<IDataResult<DeleteEmployeeResponse>> DeleteAsync(DeleteEmployeeRequest request)
        {
            return await _employeeService.DeleteAsync(request);
        }

        [HttpGet]
        public async Task<IDataResult<List<GetAllEmployeeResponse>>> GetAllAsync()
        {
            return await _employeeService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<IDataResult<GetByIdEmployeeResponse>> GetByIdAsync(int id)
        {
            return await _employeeService.GetByIdAsync(id);
        }
    }
}
