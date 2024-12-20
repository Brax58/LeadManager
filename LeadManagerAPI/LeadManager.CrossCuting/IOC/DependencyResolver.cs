﻿using LeadManager.Domain.Interfaces;
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
            AddRepositorys(services);
            AddServices(services);
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
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<ILogLeadRepository, LogLeadRepository>();
        }
        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IJobService, JobService>();
        }
    }
}
