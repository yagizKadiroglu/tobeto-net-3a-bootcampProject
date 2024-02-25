using Business.Abstracts;
using Business.Concretes;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<IApplicantService, ApplicantManager>();
        services.AddScoped<IEmployeeService, EmployeeManager>();
        services.AddScoped<IInstructorService, InstructorManager>();
        services.AddScoped<IApplicationService, ApplicationManager>();
        services.AddScoped<IApplicationStateService, ApplicationStateManager>();
        services.AddScoped<IBootcampService, BootcampManager>();
        services.AddScoped<IBootcampStateService, BootcampStateManager>();
        services.AddScoped<IUserImageService, UserImageManager>();


        return services;
    }
}
