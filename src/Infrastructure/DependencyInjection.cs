using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Infrastructure.Identity;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("CleanArchitectureDb"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

                //services.AddDefaultIdentity<ApplicationUser>()
                //    .AddEntityFrameworkStores<ApplicationDbContext>();

            //services.AddDbContext<SicomDbContext>(options =>
            //    options.UseDb2(
            //        configuration.GetConnectionString("SicomConnection"),
            //        b => b.MigrationsAssembly(typeof(SicomDbContext).Assembly.FullName)));

            //services.AddScoped<ISicomDbContext>(provider => provider.GetService<SicomDbContext>());

            //services.AddIdentityServer()
            //    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddTransient<IDateTime, DateTimeService>();
            //services.AddTransient<IIdentityService, IdentityService>();

            //services.AddAuthentication()
            //    .AddIdentityServerJwt();

            return services;
        }
    }
}
