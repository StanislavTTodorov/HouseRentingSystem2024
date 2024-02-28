using HouseRentingSystem.Data;
using HouseRentingSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServises(this IServiceCollection services)
        {

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
