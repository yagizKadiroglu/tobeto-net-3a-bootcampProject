using Core.DataAccess;
using Core.Utilities.Security.Entities;

namespace DataAccess.Abstracts;

public interface IUserRepository : IRepository<User, int>, IAsyncRepository<User, int>
{
}
