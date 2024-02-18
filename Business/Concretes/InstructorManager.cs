using Business.Abstracts;
using Business.Requests.Instructors;
using Business.Responses.Instructors;
using DataAccess.Abstracts;
using Entities;

namespace Business.Concretes;

public class InstructorManager : IInstructorService
{
    private readonly IInstructorRepository _instructorRepository;

    public InstructorManager(IInstructorRepository instructorRepository)
    {
        _instructorRepository = instructorRepository;
    }

    public CreateInstructorResponse Add(CreateInstructorRequest request)
    {
        Instructor instructor = new();
        instructor.Username = request.Username;
        instructor.FirstName = request.FirstName;
        instructor.LastName = request.LastName;
        instructor.DateOfBirth = request.DateOfBirth;
        instructor.NationalIdentity = request.NationalIdentity;
        instructor.Email = request.Email;
        instructor.Password = request.Password;
        instructor.CompanyName = request.CompanyName;

        _instructorRepository.Add(instructor);

        CreateInstructorResponse instructorResponse = new();
        instructorResponse.Username = instructor.Username;
        instructorResponse.FirstName = instructor.FirstName;
        instructorResponse.LastName = instructor.LastName;
        instructorResponse.DateOfBirth = instructor.DateOfBirth;
        instructorResponse.NationalIdentity = instructor.NationalIdentity;
        instructorResponse.Email = instructor.Email;
        instructorResponse.Password = instructor.Password;
        instructorResponse.CompanyName = instructor.CompanyName;
        instructorResponse.CreatedDate = instructor.CreatedDate;

        return instructorResponse;

    }

    public DeleteInstructorResponse Delete(DeleteInstructorRequest request)
    {
        var instructor = _instructorRepository.Get(a => a.Id == request.Id);

        _instructorRepository.Delete(instructor);

        DeleteInstructorResponse deleteInstructorResponse = new();
        deleteInstructorResponse.Username = instructor.Username;
        deleteInstructorResponse.DeletedDate = instructor.DeletedDate;


        return deleteInstructorResponse;
    }

    public List<GetAllInstructorResponse> GetAll()
    {
        List<GetAllInstructorResponse> instructorResponses = new();
        foreach (var item in _instructorRepository.GetAll())
        {
            GetAllInstructorResponse result = new();
            result.Id = item.Id;
            result.Username = item.Username;
            result.FirstName = item.FirstName;
            result.LastName = item.LastName;
            result.DateOfBirth = item.DateOfBirth;
            result.NationalIdentity = item.NationalIdentity;
            result.Email = item.Email;
            result.Password = item.Password;
            result.CompanyName = item.CompanyName;
            instructorResponses.Add(result);
        }
        return instructorResponses;


    }

    public GetByIdInstructorResponse GetById(int id)
    {
        var result = _instructorRepository.Get(a => a.Id == id);

        GetByIdInstructorResponse getByIdInstructorResponse = new();
        getByIdInstructorResponse.Id = result.Id;
        getByIdInstructorResponse.Username = result.Username;
        getByIdInstructorResponse.FirstName = result.FirstName;
        getByIdInstructorResponse.LastName = result.LastName;
        getByIdInstructorResponse.DateOfBirth = result.DateOfBirth;
        getByIdInstructorResponse.NationalIdentity = result.NationalIdentity;
        getByIdInstructorResponse.Email = result.Email;
        getByIdInstructorResponse.Password = result.Password;
        getByIdInstructorResponse.CompanyName = result.CompanyName;

        return getByIdInstructorResponse;
    }

    public UpdateInstructorResponse Update(UpdateInstructorRequest request)
    {
        var result = _instructorRepository.Get(a => a.Id == request.Id);
        result.Id = request.Id;
        result.Username = request.Username;
        result.FirstName = request.FirstName;
        result.LastName = request.LastName;
        result.DateOfBirth = request.DateOfBirth;
        result.NationalIdentity = request.NationalIdentity;
        result.Email = request.Email;
        result.Password = request.Password;
        result.CompanyName = request.CompanyName;

        _instructorRepository.Update(result);

        UpdateInstructorResponse instructorResponse = new();
        instructorResponse.Username = result.Username;
        instructorResponse.FirstName = result.FirstName;
        instructorResponse.LastName = result.LastName;
        instructorResponse.DateOfBirth = result.DateOfBirth;
        instructorResponse.NationalIdentity = result.NationalIdentity;
        instructorResponse.Email = result.Email;
        instructorResponse.Password = result.Password;
        instructorResponse.CompanyName = result.CompanyName;
        instructorResponse.UpdatedDate = result.UpdatedDate;

        return instructorResponse;
    }
}

