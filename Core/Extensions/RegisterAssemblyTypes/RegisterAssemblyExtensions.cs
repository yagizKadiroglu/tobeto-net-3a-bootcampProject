using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions.RegisterAssemblyTypes
{
    public static class RegisterAssemblyExtensions
    {
        public static IServiceCollection RegisterAssemblyTypes
        (this IServiceCollection services, Assembly assembly)
        {
            var types = assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract);
            foreach (Type? type in types)
            {
                var interfaces = type.GetInterfaces();
                foreach (var @interface in interfaces)
                {
                    services.AddScoped(@interface, type);
                }
            }
            return services;
        }
    }
}
