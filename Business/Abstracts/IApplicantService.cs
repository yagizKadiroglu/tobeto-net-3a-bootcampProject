using Business.Requests.Applicants;
using Business.Responses.Applicants;

namespace Business.Abstracts;

public interface IApplicantService
{
    CreateApplicantResponse Add(CreateApplicantRequest request);
    DeleteApplicantResponse Delete(DeleteApplicantRequest request);
    UpdateApplicantResponse Update(UpdateApplicantRequest request);
    List<GetAllApplicantResponse> GetAll();
    GetByIdApplicantResponse GetById(int id);

}
