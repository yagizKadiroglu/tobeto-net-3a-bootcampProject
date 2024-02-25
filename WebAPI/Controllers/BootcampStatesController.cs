using Business.Abstracts;
using Business.Requests.BootcampStates;
using Business.Responses.BootcampStates;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BootcampStatesController : BaseController
    {
        private readonly IBootcampStateService _bootcampStateService;

        public BootcampStatesController(IBootcampStateService bootcampStateService)
        {
            _bootcampStateService = bootcampStateService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateBootcampStateRequest request)
        {

            return HandleDataResult(await _bootcampStateService.AddAsync(request));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateBootcampStateRequest request)
        {
            return HandleDataResult(await _bootcampStateService.UpdateAsync(request));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(DeleteBootcampStateRequest request)
        {
            return HandleDataResult(await _bootcampStateService.DeleteAsync(request));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return HandleDataResult(await _bootcampStateService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return HandleDataResult(await _bootcampStateService.GetByIdAsync(id));
        }
    }
}
