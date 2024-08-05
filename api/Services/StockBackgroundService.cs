using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

public class StockBackgroundService : BackgroundService
{
    private readonly StockDataFetcher _fetcher;
    private readonly ILogger<StockBackgroundService> _logger;

    public StockBackgroundService(StockDataFetcher fetcher, ILogger<StockBackgroundService> logger)
    {
        _fetcher = fetcher;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var stocks = await _fetcher.FetchStockDataAsync();
                await _fetcher.PostStockDataAsync(stocks);
                await Task.Delay(TimeSpan.FromMinutes(15), stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in the background service: {Message}", ex.Message);
            }
        }
    }
}
