using DixRacing.DataAccess;
using DixRacing.Domain.Races.Services;
using DixRacing.Domain.SharedKernel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DixRacing.Workers
{
    public class ResultWorker : BackgroundService
    {
        private readonly ILogger<ResultWorker> _logger;
        private readonly IConfiguration _config;


        public ResultWorker(ILogger<ResultWorker> logger,
                            IConfiguration config

                            )
        {
            _logger = logger;
            _config = config;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var services = new ServiceCollection();
            services.AddDbContext<DixRacingDbContext>();
            services.AddScoped<ReadResultService>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            using (var _serviceProvider = services.BuildServiceProvider())
            {
                using (IServiceScope scope = _serviceProvider.CreateScope())
                {
                    var raceResultService = scope.ServiceProvider.GetRequiredService<ReadResultService>();
                    var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                    var directoryPath = _config.GetSection("RaceResultPath");
                    System.IO.Directory.CreateDirectory(directoryPath.Value + @"\cpy");
                    DirectoryInfo d = new DirectoryInfo(directoryPath.Value);
                    while (!stoppingToken.IsCancellationRequested)
                    {
                        foreach (var file in d.GetFiles("*.json"))
                        {
                            try
                            {
                                var resultsText = await File.ReadAllTextAsync(file.FullName, Encoding.Unicode);
                                var results = JsonConvert.DeserializeObject<AccResult>(resultsText);
                                if (results is not null)
                                {
                                    await unitOfWork.ExecuteInTransactionAsync(async () =>
                                    {
                                        if (await raceResultService.ReadResultAccAsync(results))
                                            file.MoveTo(file.DirectoryName + @"\cpy\" + file.Name);
                                    });
                                }
                            }
                            catch (ArgumentException e)
                            {
                                _logger.LogInformation("Error: {e}", e.Message);
                            }
                        }
                        await Task.Delay(10000, stoppingToken);
                    }

                }

            }
        }
    }
}