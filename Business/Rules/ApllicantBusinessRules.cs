using Business.Constants;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;

namespace Business.Rules;

public class ApllicantBusinessRules:BaseBusinessRules
{
    private readonly IApplicantRepository _applicantRepository;

    public ApllicantBusinessRules(IApplicantRepository applicantRepository)
    {
        _applicantRepository = applicantRepository;
    }

    public async Task IsDeletedCheck(int id)
    {
        var isDelete = await _applicantRepository.GetAsync(a => a.Id == id);

        if (isDelete is null) throw new BusinessException(ApplicantBusinessRuleMessage.IsDeletedCheck);
    }

    public async Task IsApplicantExist(string userName,string nationalIdentity,string email)
    {
        var isApplicantExist = await _applicantRepository.GetAsync(a => 
            a.Username == userName || 
            a.NationalIdentity == nationalIdentity ||
            a.Email == email
            );

        if (isApplicantExist is not null) throw new BusinessException(ApplicantBusinessRuleMessage.IsApplicantExist);
    }
}
