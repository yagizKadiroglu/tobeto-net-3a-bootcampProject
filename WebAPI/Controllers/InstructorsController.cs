using Business.Abstracts;
using Business.Requests.Instructors;
using Business.Responses.Instructors;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        private readonly IInstructorService _instructorService;

        public InstructorsController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpPost]
        public async Task<IDataResult<CreateInstructorResponse>> AddAsync(CreateInstructorRequest request)
        {
            return await _instructorService.AddAsync(request);
        }

        [HttpPut]
        public async Task<IDataResult<UpdateInstructorResponse>> UpdateAsync(UpdateInstructorRequest request)
        {
            return await _instructorService.UpdateAsync(request);
        }

        [HttpDelete]
        public async Task<IDataResult<DeleteInstructorResponse>> DeleteAsync(DeleteInstructorRequest request)
        {
            return await _instructorService.DeleteAsync(request);
        }

        [HttpGet]
        public async Task<IDataResult<List<GetAllInstructorResponse>>> GetAllAsync()
        {
            return await _instructorService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<IDataResult<GetByIdInstructorResponse>> GetByIdAsync(int id)
        {
            return await _instructorService.GetByIdAsync(id);
        }
    }
}
