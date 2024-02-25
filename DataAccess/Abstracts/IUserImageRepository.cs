using Core.DataAccess;
using Entities;

namespace DataAccess.Abstracts;

public interface IUserImageRepository : IRepository<UserImage, int>, IAsyncRepository<UserImage, int>
{
}

