using Core.CrossCuttingConcerns;
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

        if (isDelete is null) throw new BusinessException("applicant is not exist");

    }
}
