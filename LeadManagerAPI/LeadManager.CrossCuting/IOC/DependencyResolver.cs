using LeadManager.Domain.Interfaces;
using LeadManager.Repository.Context;
using LeadManager.Repository.Repository;
using LeadManager.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LeadManager.CrossCuting.IOC
{
    public static class DependencyResolver
    {
        public static void AddDependencyResolver(this IServiceCollection services) 
        {
            AddConnectionDataBase(services);
            AddServices(services);
            AddRepositorys(services);
        }

        private static void AddConnectionDataBase(IServiceCollection services)
        {
            services.AddDbContext<LeadManagerContext>(options =>
                options.UseSqlServer(Environment.GetEnvironmentVariable("LeadManagerDBConnection"))
            );

            services.BuildServiceProvider().GetService<LeadManagerContext>();
        }

        private static void AddRepositorys(IServiceCollection services) 
        {
            services.AddScoped<ILeadManagerRepository, LeadManagerRepository>();
        }
        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<ILeadManagerService, LeadManagerService>();
        }
    }
}
