using Business.Abstracts;
using Business.Requests.Bootcamps;
using Business.Responses.Bootcamps;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BootcampsController : BaseController
    {
        private readonly IBootcampService _bootcampService;

        public BootcampsController(IBootcampService bootcampService)
        {
            _bootcampService = bootcampService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateBootcampRequest request)
        {
            return HandleDataResult(await _bootcampService.AddAsync(request));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateBootcampRequest request)
        {
            return HandleDataResult(await _bootcampService.UpdateAsync(request));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(DeleteBootcampRequest request)
        {
            return HandleDataResult(await _bootcampService.DeleteAsync(request));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return HandleDataResult(await _bootcampService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return HandleDataResult(await _bootcampService.GetByIdAsync(id));
        }
    }
}
