using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API
{
    public static class ApplicationServiceExtensions
    {
        public static  IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            return services;
        }   
    }
}