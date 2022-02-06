using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using DixRacing.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DixRacing.Data.Repositories;
using DixRacing.Data.Interfaces;
using DixRacing.Services.Interfaces;
using DixRacing.Services;
using DixRacing.Workers;
using Microsoft.OpenApi.Models;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<ISignForEvent, SignForEvent>();
            services.AddScoped<IResignFromEvent, ResignFromEvent>();
            services.AddScoped<IRaceConfirmation, RaceConfirmation>();
            services.AddScoped<IRaceRepository, RaceRepository>();
            services.AddScoped<IResultManager, ResultManager>();
            services.AddScoped<IRoundsRepository, RoundsRepository>();
            services.AddScoped<IRaceResultsService, RaceResultsService>();
            services.AddScoped<IRaceResultsRepository, RaceResultsRepository>();
            services.AddScoped<IEventParticipantsRepository, EventParticipantsRepository>();
            services.AddHostedService<ResultWorker>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IRoundService, RoundService>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("API"));

            });

            services.AddControllersWithViews()
                    .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                        );
           
            return services;

        }
    }
}