using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DixRacing.DataAccess;
using API.Infrastructure.Decorators;
using MediatR;
using System.Reflection;
using DixRacing.Domain.SharedKernel;
using DixRacing.DataAccess.Queries.Event;
using DixRacing.Domain.Events.Queries;
using API.Helpers;
using DixRacing.Domain.Users.Commands;
using DixRacing.Domain.Users.Commands.Login;
using Microsoft.AspNetCore.Http;

namespace API.Infrastructure.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddDataAccessDependencies(configuration)
                .AddApiDependencies()
                .AddDomainDependencies();
        }

        private static IServiceCollection AddApiDependencies(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.Load("API"));
            services.Decorate(typeof(IRequestHandler<,>), typeof(TransactionalRequestHandlerDecorator<,>));

            return services;
        }

        private static IServiceCollection AddDataAccessDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<DixRacingDbContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("DixRacing.DataAccess"));

            });
            services.Scan(scan =>
                scan.FromAssemblies(Assembly.Load("DixRacing.DataAccess"))
                    .AddClasses(classes => classes
                        .Where(c => c.FullName!.EndsWith("Query")))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddControllersWithViews()
                    .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                        );
            services.AddTransient((_) => new DapperContext(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
        private static IServiceCollection AddDomainDependencies(this IServiceCollection services)
        {
            services.Scan(scan =>
            scan.FromAssemblies(Assembly.Load("DixRacing.Domain"))
                .AddClasses(classes => classes
                    .Where(c => c.FullName!.EndsWith("Service")))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }
    }
}
