using Core.Extensions.RegisterAssemblyTypes;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Contexts;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DataAccess;

public static class DataAccessServiceRegistration
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>
            (options => options.UseSqlServer(configuration.
            GetConnectionString("TobetoNetConnectionString")));

        //services.AddScoped<IUserRepository, UserRepository>();
        //services.AddScoped<IApplicantRepository, ApplicantRepository>();
        //services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        //services.AddScoped<IInstructorRepository, InstructorRepository>();
        //services.AddScoped<IApplicationRepository, ApplicationRepository>();
        //services.AddScoped<IApplicationStateRepository, ApplicationStateRepository>();
        //services.AddScoped<IBootcampRepository, BootcampRepository>();
        //services.AddScoped<IBootcampStateRepository, BootcampStateRepository>();
        //services.AddScoped<IUserImageRepository, UserImageRepository>();
        //services.AddScoped<IBlackListRepository, BlackListRepository>();

        services.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(x => x.ServiceType.Name.EndsWith("Repository"));


        return services;
    }
}
