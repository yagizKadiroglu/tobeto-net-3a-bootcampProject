using Core.DataAccess;
using Entities;

namespace DataAccess.Abstracts;

public interface IBlackListRepository : IRepository<BlackList, int>, IAsyncRepository<BlackList, int>
{
}
