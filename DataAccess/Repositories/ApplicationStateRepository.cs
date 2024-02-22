using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Contexts;
using Entities;

namespace DataAccess.Repositories;

public class ApplicationStateRepository : EfRepositoryBase<ApplicationState, int, BaseDbContext>, IApplicationStateRepository
{
    public ApplicationStateRepository(BaseDbContext context) : base(context)
    {
    }
}
