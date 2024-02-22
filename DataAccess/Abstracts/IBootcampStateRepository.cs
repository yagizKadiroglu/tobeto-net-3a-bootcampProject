using Core.DataAccess;
using Entities;

namespace DataAccess.Abstracts;

public interface IBootcampStateRepository : IRepository<BootcampState, int>, IAsyncRepository<BootcampState, int>
{
}
