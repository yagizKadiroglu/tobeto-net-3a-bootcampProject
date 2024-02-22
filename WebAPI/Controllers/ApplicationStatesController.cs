using Business.Abstracts;
using Business.Requests.ApplicationStates;
using Business.Responses.ApplicationStates;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationStatesController : ControllerBase
    {
        private readonly IApplicationStateService _applicationStateService;

        public ApplicationStatesController(IApplicationStateService applicationStateService)
        {
            _applicationStateService = applicationStateService;
        }

        [HttpPost]
        public async Task<IDataResult<CreateApplicationStateResponse>> AddAsync(CreateApplicationStateRequest request)
        {
            return await _applicationStateService.AddAsync(request);
        }

        [HttpPut]
        public async Task<IDataResult<UpdateApplicationStateResponse>> UpdateAsync(UpdateApplicationStateRequest request)
        {
            return await _applicationStateService.UpdateAsync(request);
        }

        [HttpDelete]
        public async Task<IDataResult<DeleteApplicationStateResponse>> DeleteAsync(DeleteApplicationStateRequest request)
        {
            return await _applicationStateService.DeleteAsync(request);
        }

        [HttpGet]
        public async Task<IDataResult<List<GetAllApplicationStateResponse>>> GetAllAsync()
        {
            return await _applicationStateService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<IDataResult<GetByIdApplicationStateResponse>> GetByIdAsync(int id)
        {
            return await _applicationStateService.GetByIdAsync(id);
        }
    }
}
