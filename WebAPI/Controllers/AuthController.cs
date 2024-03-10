using Business.Abstracts;
using Business.Requests.Applicants;
using Business.Requests.Employees;
using Business.Requests.Instructors;
using Core.Utilities.Security.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("applicant-register")]
        public async Task<IActionResult> ApplicantRegister(RegisterApplicantRequest registerApplicantRequest)
        {
            var result = await _authService.ApplicantRegister(registerApplicantRequest);
            return HandleDataResult(result);
        }

        [HttpPost("employee-register")]
        public async Task<IActionResult> EmployeeRegister(RegisterEmployeeRequest registerEmployeeRequest)
        {
            var result = await _authService.EmployeeRegister(registerEmployeeRequest);
            return HandleDataResult(result);
        }

        [HttpPost("instructor-register")]
        public async Task<IActionResult> InstructorRegister(RegisterInstructorRequest registerInstructorRequest)
        {
            var result = await _authService.InstructorRegister(registerInstructorRequest);
            return HandleDataResult(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var result = await _authService.Login(userForLoginDto);
            return HandleDataResult(result);
        }

    }
}