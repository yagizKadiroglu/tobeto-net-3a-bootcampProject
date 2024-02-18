using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Contexts;
using Entities;

namespace DataAccess.Repositories;

public class ApplicantRepository : EfRepositoryBase<Applicant, int, BaseDbContext>, IApplicantRepository
{
    public ApplicantRepository(BaseDbContext context) : base(context)
    {
    }
}
