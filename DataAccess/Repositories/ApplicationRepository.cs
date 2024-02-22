using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Contexts;
using Entities;

namespace DataAccess.Repositories;

public class ApplicationRepository : EfRepositoryBase<Application, int, BaseDbContext>, IApplicationRepository
{
    public ApplicationRepository(BaseDbContext context) : base(context)
    {
    }
}
