using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Contexts;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class DataAccessServiceRegistration
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>
            (options => options.UseSqlServer(configuration.
            GetConnectionString("TobetoNetConnectionString")));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IApplicantRepository, ApplicantRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IInstructorRepository, InstructorRepository>();

        return services;
    }
}
