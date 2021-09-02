using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StockData.Stock.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StockData.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IStockPriceService _stockPriceService;
        public Worker(ILogger<Worker> logger, IStockPriceService stockPriceService)
        {
            _logger = logger;
            _stockPriceService = stockPriceService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _stockPriceService.ScrapData();
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(60000, stoppingToken);
            }
        }
    }
}
