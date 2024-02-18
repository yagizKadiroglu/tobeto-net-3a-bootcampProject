using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Contexts;
using Entities;

namespace DataAccess.Repositories;

public class InstructorRepository : EfRepositoryBase<Instructor, int, BaseDbContext>, IInstructorRepository
{
    public InstructorRepository(BaseDbContext context) : base(context)
    {
    }
}
