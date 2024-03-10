using Business.Requests.Applicants;
using Business.Requests.Employees;
using Business.Requests.Instructors;
using Core.Utilities.Results;
using Core.Utilities.Security.Dtos;
using Core.Utilities.Security.Entities;
using Core.Utilities.Security.JWT;

namespace Business.Abstracts;

public interface IAuthService
{
    Task<DataResult<AccessToken>> Login(UserForLoginDto userForLoginDto);
    Task<DataResult<AccessToken>> ApplicantRegister(RegisterApplicantRequest registerApplicantRequest);
    Task<DataResult<AccessToken>> InstructorRegister(RegisterInstructorRequest registerInstructorRequest);
    Task<DataResult<AccessToken>> EmployeeRegister(RegisterEmployeeRequest registerEmployeeRequest);
    Task<DataResult<AccessToken>> CreateAccessToken(User user);
}
