using Business.Abstracts;
using Business.Requests.BlackLists;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlackListsController : BaseController
    {
        private readonly IBlackListService _blackListService;

        public BlackListsController(IBlackListService blackListService)
        {
            _blackListService = blackListService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateBlackListRequest request)
        {
            return HandleDataResult(await _blackListService.AddAsync(request));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateBlackListRequest request)
        {
            return HandleDataResult(await _blackListService.UpdateAsync(request));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(DeleteBlackListRequest request)
        {
            return HandleDataResult(await _blackListService.DeleteAsync(request));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return HandleDataResult(await _blackListService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return HandleDataResult(await _blackListService.GetByIdAsync(id));
        }
    }
}
