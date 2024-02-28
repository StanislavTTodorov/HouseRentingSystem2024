using HouseRentingSystem.Data;
using HouseRentingSystem.Data.Models;
using Microsoft.EntityFrameworkCore;

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
                options.SignIn.RequireConfirmedAccount = true;
            })
              .AddEntityFrameworkStores<HouseRentingDbContext>();
            return services;
        }

    }
}
