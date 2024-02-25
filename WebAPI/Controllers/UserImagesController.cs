using Business.Abstracts;
using Business.Requests.UserImages;
using Business.Responses.UserImages;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserImagesController : BaseController
    {
        private readonly IUserImageService _userImageService;

        public UserImagesController(IUserImageService userImageService)
        {
            _userImageService = userImageService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateUserImageRequest request)
        {
            return HandleDataResult(await _userImageService.AddAsync(request));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateUserImageRequest request)
        {
            return HandleDataResult(await _userImageService.UpdateAsync(request));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(DeleteUserImageRequest request)
        {
            return HandleDataResult(await _userImageService.DeleteAsync(request));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return HandleDataResult(await _userImageService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return HandleDataResult(await _userImageService.GetByIdAsync(id));
        }
    }
}
