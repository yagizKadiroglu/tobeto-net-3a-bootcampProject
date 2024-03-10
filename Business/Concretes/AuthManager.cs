using Business.Abstracts;
using Business.Requests.Applicants;
using Business.Requests.Employees;
using Business.Requests.Instructors;
using Business.Rules;
using Core.Exceptions.Types;
using Core.Utilities.Results;
using Core.Utilities.Security.Dtos;
using Core.Utilities.Security.Entities;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Abstracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class AuthManager : IAuthService
{
    private readonly AuthBusinessRules _rules;
    private readonly ITokenHelper _tokenHelper;
    private readonly IUserRepository _userRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IApplicantRepository _applicantRepository;
    private readonly IInstructorRepository _instructorRepository;
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;

    public AuthManager(ITokenHelper tokenHelper, IUserOperationClaimRepository userOperationClaimRepository, IApplicantRepository applicantRepository, AuthBusinessRules rules, IInstructorRepository instructorRepository, IEmployeeRepository employeeRepository, IUserRepository userRepository)
    {
        _rules = rules;
        _tokenHelper = tokenHelper;
        _userRepository = userRepository;
        _employeeRepository = employeeRepository;
        _applicantRepository = applicantRepository;
        _instructorRepository = instructorRepository;
        _userOperationClaimRepository = userOperationClaimRepository;
    }

    public async Task<DataResult<AccessToken>> CreateAccessToken(User user)
    {
        List<OperationClaim> claims = await _userOperationClaimRepository.Query()
            .AsNoTracking().Where(x => x.UserId == user.Id).Select(x => new OperationClaim
            {
                Id = x.OperationClaimId,
                Name = x.OperationClaim.Name
            }).ToListAsync();
        var accessToken = _tokenHelper.CreateToken(user, claims);
        return new SuccessDataResult<AccessToken>(accessToken, "Created Token");

    }

    public async Task<DataResult<AccessToken>> Login(UserForLoginDto userForLoginDto)
    {
        var user = await _userRepository.GetAsync(x=>
            x.Email == userForLoginDto.LoginInformation ||
            x.NationalIdentity == userForLoginDto.LoginInformation ||
            x.Username == userForLoginDto.LoginInformation);

        await _rules.UserShouldBeExists(user);
        await _rules.UserEmailOrNationalIdentityOrUsernameShouldBeExists(userForLoginDto.LoginInformation);
        await _rules.UserPasswordShouldBeMatch(user.Id, userForLoginDto.Password);

        var createAccessToken = await CreateAccessToken(user);
        return new SuccessDataResult<AccessToken>(createAccessToken.Data, "Login Success");
    }

    public async Task<DataResult<AccessToken>> ApplicantRegister(RegisterApplicantRequest registerApplicantRequest)
    {
        await _rules.UserEmailOrNationalIdentityOrUsernameShouldBeNotExists(
            registerApplicantRequest.Email,
            registerApplicantRequest.NationalIdentity,
            registerApplicantRequest.Username);
        
        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(registerApplicantRequest.Password, out passwordHash, out passwordSalt);
        var applicant = new Applicant
        {
            Username = registerApplicantRequest.Username,
            FirstName = registerApplicantRequest.FirstName,
            LastName = registerApplicantRequest.LastName,
            DateOfBirth = registerApplicantRequest.DateOfBirth,
            NationalIdentity = registerApplicantRequest.NationalIdentity,
            Email = registerApplicantRequest.Email,
            About = registerApplicantRequest.About,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };
        await _applicantRepository.AddAsync(applicant);
        var createAccessToken = await CreateAccessToken(applicant);
        return new SuccessDataResult<AccessToken>(createAccessToken.Data, "Register Success");
    }

    public async Task<DataResult<AccessToken>> InstructorRegister(RegisterInstructorRequest registerInstructorRequest)
    {
        await _rules.UserEmailOrNationalIdentityOrUsernameShouldBeNotExists(
           registerInstructorRequest.Email,
           registerInstructorRequest.NationalIdentity,
           registerInstructorRequest.Username);

        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(registerInstructorRequest.Password, out passwordHash, out passwordSalt);
        var instructor = new Instructor
        {
            Username = registerInstructorRequest.Username,
            FirstName = registerInstructorRequest.FirstName,
            LastName = registerInstructorRequest.LastName,
            DateOfBirth = registerInstructorRequest.DateOfBirth,
            NationalIdentity = registerInstructorRequest.NationalIdentity,
            Email = registerInstructorRequest.Email,
            CompanyName = registerInstructorRequest.CompanyName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };
        await _instructorRepository.AddAsync(instructor);
        var createAccessToken = await CreateAccessToken(instructor);
        return new SuccessDataResult<AccessToken>(createAccessToken.Data, "Register Success");
    }

    public async Task<DataResult<AccessToken>> EmployeeRegister(RegisterEmployeeRequest registerEmployeeRequest)
    {
        await _rules.UserEmailOrNationalIdentityOrUsernameShouldBeNotExists(
           registerEmployeeRequest.Email,
           registerEmployeeRequest.NationalIdentity,
           registerEmployeeRequest.Username);

        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(registerEmployeeRequest.Password, out passwordHash, out passwordSalt);
        var employee = new Employee
        {
            Username = registerEmployeeRequest.Username,
            FirstName = registerEmployeeRequest.FirstName,
            LastName = registerEmployeeRequest.LastName,
            DateOfBirth = registerEmployeeRequest.DateOfBirth,
            NationalIdentity = registerEmployeeRequest.NationalIdentity,
            Email = registerEmployeeRequest.Email,
            Position = registerEmployeeRequest.Position,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };
        await _employeeRepository.AddAsync(employee);
        var createAccessToken = await CreateAccessToken(employee);
        return new SuccessDataResult<AccessToken>(createAccessToken.Data, "Register Success");
    }

}