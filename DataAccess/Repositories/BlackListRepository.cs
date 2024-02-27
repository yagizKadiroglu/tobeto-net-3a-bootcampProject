using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Contexts;
using Entities;

namespace DataAccess.Repositories;

internal class BlackListRepository : EfRepositoryBase<BlackList, int, BaseDbContext>, IBlackListRepository
{
    public BlackListRepository(BaseDbContext context) : base(context)
    {
    }
}
