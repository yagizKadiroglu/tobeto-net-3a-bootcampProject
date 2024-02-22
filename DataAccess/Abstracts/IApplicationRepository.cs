using Core.DataAccess;
using Entities;

namespace DataAccess.Abstracts;

public interface IApplicationRepository : IRepository<Application, int>, IAsyncRepository<Application, int>
{
}
