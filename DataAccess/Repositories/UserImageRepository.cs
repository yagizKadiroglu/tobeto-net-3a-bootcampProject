using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Contexts;
using Entities;

namespace DataAccess.Repositories;

public class UserImageRepository : EfRepositoryBase<UserImage, int, BaseDbContext>, IUserImageRepository
{
    public UserImageRepository(BaseDbContext context) : base(context)
    {
    }
}

