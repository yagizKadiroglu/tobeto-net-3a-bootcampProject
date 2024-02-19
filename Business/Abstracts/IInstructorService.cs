using Business.Requests.Instructors;
using Business.Responses.Instructors;

namespace Business.Abstracts;

public interface IInstructorService
{
    Task<CreateInstructorResponse> AddAsync(CreateInstructorRequest request);
    Task<DeleteInstructorResponse> DeleteAsync(DeleteInstructorRequest request);
    Task<UpdateInstructorResponse> UpdateAsync(UpdateInstructorRequest request);
    Task<List<GetAllInstructorResponse>> GetAllAsync();
    Task<GetByIdInstructorResponse> GetByIdAsync(int id);

}
