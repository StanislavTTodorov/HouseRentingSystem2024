using HouseRentingSystem.Data;
using HouseRentingSystem.Data.Models;
using HouseRentingSystem.Services.Data;
using HouseRentingSystem.Services.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        /// <summary>
        ///  This method registers all services with their interfaces and implementations of given assembly.
        ///  The assembly is taken from the type of random service implementation provided. 
        /// </summary>
        /// <param name="serviceType">Type of random service implementation </param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static IServiceCollection AddApplicationServises(this IServiceCollection services,Type serviceType)
        {
            Assembly? serviceAssembly =Assembly.GetAssembly(serviceType);
            if (serviceAssembly == null)
            {
                throw new InvalidOperationException("Invalid Service type provided!");
            }
            Type[] serviceTypes = serviceAssembly
                .GetTypes()
                .Where(t => t.Name.EndsWith("Service") && !t.IsInterface)
                .ToArray();
            foreach (Type implamentationType in serviceTypes)
            {
                Type? interfaceType = implamentationType.GetInterface($"I{implamentationType.Name}");

                if (interfaceType == null)
                {
                    throw new InvalidOperationException($"No Interface is provided for the service whih name: {implamentationType.Name}");
                }
                services.AddScoped(interfaceType, implamentationType);
            }

            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            string connectionString = config.GetConnectionString("DefaultConnection") ?? throw new ArgumentException();

            services.AddDbContext<HouseRentingDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;

        }
        public static IServiceCollection AddApplicationIdentiry(this IServiceCollection services, IConfiguration config)
        {

            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = config.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
                options.Password.RequireDigit = config.GetValue<bool>("Identity:Password:RequireDigit");
                options.Password.RequireNonAlphanumeric = config.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
                options.Password.RequireLowercase = config.GetValue<bool>("Identity:Password:RequireLowercase");
                options.Password.RequireUppercase = config.GetValue<bool>("Identity:Password:RequireUppercase");
                options.Password.RequiredLength = config.GetValue<int>("Identity:Password:RequiredLength");
            })
              .AddEntityFrameworkStores<HouseRentingDbContext>();
            return services;
        }

    }
}
