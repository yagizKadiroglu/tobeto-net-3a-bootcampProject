using Business.Abstracts;
using Business.Requests.Employees;
using Business.Responses.Employees;
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
        public CreateEmployeeResponse Add(CreateEmployeeRequest request)
        {
            return _employeeService.Add(request);
        }

        [HttpPut]
        public UpdateEmployeeResponse Update(UpdateEmployeeRequest request)
        {
            return _employeeService.Update(request);
        }

        [HttpDelete]
        public DeleteEmployeeResponse Delete(DeleteEmployeeRequest request)
        {
            return _employeeService.Delete(request);
        }

        [HttpGet]
        public List<GetAllEmployeeResponse> GetAll()
        {
            return _employeeService.GetAll();
        }

        [HttpGet("{id}")]
        public GetByIdEmployeeResponse GetById(int id)
        {
            return _employeeService.GetById(id);
        }
    }
}
