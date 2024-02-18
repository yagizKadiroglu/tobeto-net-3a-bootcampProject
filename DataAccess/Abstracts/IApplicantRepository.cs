using Core.DataAccess;
using Entities;

namespace DataAccess.Abstracts;

public interface IApplicantRepository : IRepository<Applicant, int>
{
}
