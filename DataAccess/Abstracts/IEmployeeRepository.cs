using Core.DataAccess;
using Entities;

namespace DataAccess.Abstracts;

public interface IEmployeeRepository : IRepository<Employee, int>, IAsyncRepository<Employee, int>
{
}
