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
        private readonly IServiceProvider _serviceProvider;

        public ResultWorker(ILogger<ResultWorker> logger, IConfiguration config, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _config = config;

            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (IServiceScope scope = _serviceProvider.CreateScope())
            {

                var directoryPath = _config.GetSection("RaceResultPath");
                DirectoryInfo d = new DirectoryInfo(directoryPath.Value);
                System.IO.Directory.CreateDirectory(directoryPath.Value + @"\cpy");
                while (!stoppingToken.IsCancellationRequested)
                {
                    foreach (var file in d.GetFiles("*.json"))
                    {
                        try
                        {
                            var resultsText = await File.ReadAllTextAsync(file.FullName, Encoding.Unicode);
                            var results = JsonConvert.DeserializeObject<AccResult>( resultsText);
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