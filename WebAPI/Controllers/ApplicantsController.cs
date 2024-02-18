using Business.Abstracts;
using Business.Requests.Applicants;
using Business.Responses.Applicants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantsController : ControllerBase
    {
        private readonly IApplicantService _applicantService;

        public ApplicantsController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }

        [HttpPost]
        public CreateApplicantResponse Add(CreateApplicantRequest request)
        {
            return  _applicantService.Add(request);
        }

        [HttpPut]
        public UpdateApplicantResponse Update(UpdateApplicantRequest request)
        {
            return _applicantService.Update(request);
        }

        [HttpDelete]
        public DeleteApplicantResponse Delete(DeleteApplicantRequest request)
        {
            return _applicantService.Delete(request);
        }

        [HttpGet]
        public List<GetAllApplicantResponse> GetAll()
        {
            return  _applicantService.GetAll();
        }

        [HttpGet("{id}")]
        public GetByIdApplicantResponse GetById(int id)
        {
            return _applicantService.GetById(id);
        }
    }
}
