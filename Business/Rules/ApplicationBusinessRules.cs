using Business.Abstracts;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;

namespace Business.Rules;

public class ApplicationBusinessRules: BaseBusinessRules
{
    private readonly IBlackListService _blackListService;

    public ApplicationBusinessRules(IBlackListService blackListService)
    {
        _blackListService = blackListService;
    }

    public async Task BlackListCheck(int id)
    {
       var blackList = await  _blackListService.GetByApplicantIdAsync(id);

        if (blackList is not null) throw new BusinessException("Kara listede olduğu için eğitim alamaz.");
    }
}
