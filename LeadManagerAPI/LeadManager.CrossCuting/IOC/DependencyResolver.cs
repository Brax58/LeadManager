using LeadManager.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LeadManager.CrossCuting.IOC
{
    public static class DependencyResolver
    {
        public static void AddDependencyResolver(this IServiceCollection services, IConfigurationRoot configuration) 
        {
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<LeadManagerContext>(options => options.UseNpgsql(configuration.GetConnectionString("LeadManagerDBConnection")));

            services.BuildServiceProvider().GetService<LeadManagerContext>();
        }
    }
}
