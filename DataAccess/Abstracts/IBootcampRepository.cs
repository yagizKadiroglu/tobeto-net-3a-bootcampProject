using Core.DataAccess;
using Entities;

namespace DataAccess.Abstracts;

public interface IBootcampRepository : IRepository<Bootcamp, int>, IAsyncRepository<Bootcamp, int>
{
}
