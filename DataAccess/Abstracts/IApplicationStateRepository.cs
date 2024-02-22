using Core.DataAccess;
using Entities;

namespace DataAccess.Abstracts;

public interface IApplicationStateRepository : IRepository<ApplicationState, int>, IAsyncRepository<ApplicationState, int>
{
}
