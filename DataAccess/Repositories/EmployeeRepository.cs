using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Contexts;
using Entities;

namespace DataAccess.Repositories;

public class EmployeeRepository : EfRepositoryBase<Employee, int, BaseDbContext>, IEmployeeRepository
{
    public EmployeeRepository(BaseDbContext context) : base(context)
    {
    }
}
