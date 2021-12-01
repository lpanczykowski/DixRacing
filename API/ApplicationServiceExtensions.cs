using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using DixRacing.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public static class ApplicationServiceExtensions
    {
        public static  IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {

            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"), x=>x.MigrationsAssembly("API"));

            });
            return services;
            
        }   
    }
}