using Core.DataAccess;
using Entities;

namespace DataAccess.Abstracts;

public interface IInstructorRepository : IRepository<Instructor, int>, IAsyncRepository<Instructor, int>
{
}
