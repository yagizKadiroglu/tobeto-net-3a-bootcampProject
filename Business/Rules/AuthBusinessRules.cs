using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using Core.Utilities.Security.Entities;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstracts;
using Entities;

namespace Business.Rules;

public class AuthBusinessRules : BaseBusinessRules
{
    private IUserRepository _userRepository;

    public AuthBusinessRules(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task UserEmailOrNationalIdentityOrUsernameShouldBeNotExists(string email,string nationalIdentity,string username)
    {
        User? user = await _userRepository.GetAsync(
            u => u.Email == email ||
            u.NationalIdentity == nationalIdentity ||
            u.Username == username
            );
        if (user is not null) throw new BusinessException("User already exists");
    }

    public async Task UserPasswordShouldBeMatch(int id, string password)
    {
        User? user = await _userRepository.GetAsync(u => u.Id == id);
        if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            throw new BusinessException("User Information or Password don't match");
    }

    public Task UserShouldBeExists(User? user)
    {
        if (user is null) throw new BusinessException("User Information or Password don't match");
        return Task.CompletedTask;
    }

    public async Task UserEmailOrNationalIdentityOrUsernameShouldBeExists(string loginInformation)
    {
        User? user = await _userRepository.GetAsync(
            u => u.Email == loginInformation ||
            u.NationalIdentity == loginInformation ||
            u.Username == loginInformation
            );
        if (user is null) throw new BusinessException("User Information or Password don't match");
    }
}
