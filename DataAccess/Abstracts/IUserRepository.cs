using Core.DataAccess;
using Entities;

namespace DataAccess.Abstracts;

public interface IUserRepository : IRepository<User, int>
{
}
