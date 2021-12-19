using DixRacing.Core.Models.ResultModels;
using DixRacing.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace DixRacing.Services
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _config;
        private readonly IResultManager _resultManager;
        private readonly IServiceProvider _serviceProvider;

        public Worker(ILogger<Worker> logger, IConfiguration config, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _config = config;

            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                IResultManager scopedProcessingService =
                    scope.ServiceProvider.GetRequiredService<IResultManager>();

                var directoryPath = _config.GetSection("RaceResultPaths");
                DirectoryInfo d = new DirectoryInfo(directoryPath.Value);
                System.IO.Directory.CreateDirectory(directoryPath.Value + @"\cpy");
                while (!stoppingToken.IsCancellationRequested)
                {
                    foreach (var file in d.GetFiles("*.json"))
                    {
                        try
                        {
                            var resultsText = await System.IO.File.ReadAllTextAsync(file.FullName, Encoding.Unicode);
                            //resultsText.Normalize();
                            var results = JsonConvert.DeserializeObject<Results>(resultsText);
                            var stringDate = file.Name.Split("_").FirstOrDefault();
                            results.sessionDate = new DateTime(2000 + Convert.ToInt32(stringDate.Substring(0, 2)), Convert.ToInt32(stringDate.Substring(2, 2)), Convert.ToInt32(stringDate.Substring(4, 2)));
                            await scopedProcessingService.ManageResults(results);
                            file.MoveTo(file.DirectoryName + @"\cpy\" + file.Name);

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