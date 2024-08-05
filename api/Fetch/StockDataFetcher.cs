using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using api.Dtos.Stock;
using System.Collections.Generic;

public class StockDataFetcher
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly ILogger<StockDataFetcher> _logger;

    public StockDataFetcher(IHttpClientFactory clientFactory, ILogger<StockDataFetcher> logger)
    {
        _clientFactory = clientFactory;
        _logger = logger;
    }

    public async Task<List<CreateStockRequestDto>> FetchStockDataAsync()
    {
        try
        {
           

            var client = _clientFactory.CreateClient();
            var response = await client.GetStringAsync("https://borsa.doviz.com/hisseler");
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(response);

            var stockData = new List<CreateStockRequestDto>();

            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='article-content w-100']//div[@class='value-table']//div[@class='table sortable']//table[@id='stocks']//tbody//tr"); 

            if (nodes == null)
            {
                _logger.LogWarning("No stock nodes found in the HTML document.");
                return stockData;
            }

            foreach (var node in nodes)
            {
                // Read all attributes of the node
                var attributes = node.Attributes;
                var symbol = attributes["id"]?.Value;
                var name = attributes["data-name"]?.Value;
                var priceNode = node.SelectSingleNode(".//td[@class='text-bold']");

                if (symbol == null || name == null || priceNode == null)
                {
                    _logger.LogWarning("One or more nodes are missing in the HTML.");
                    continue;
                }

                var priceText = priceNode.InnerText.Trim();

                if (!decimal.TryParse(priceText, out var price))
                {
                    _logger.LogWarning($"Failed to parse price '{priceText}' for symbol '{symbol}'.");
                    continue;
                }

                stockData.Add(new CreateStockRequestDto
                {
                    Symbol = symbol,
                    Name = name,
                    Price = price,
                    Quantity = 10000 // Varsayılan olarak 10000 koyduk
                });
            }

            return stockData;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while fetching stock data.");
            throw;
        }
    }

    public async Task PostStockDataAsync(List<CreateStockRequestDto> stocks)
{
    var handler = new HttpClientHandler
    {
        ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
    };
    var client = new HttpClient(handler);
    var baseUrl = "http://localhost:5284/api/stock";

    foreach (var stock in stocks)
    {
        try
        {
            // Check if the stock already exists and get its ID
            var getResponse = await client.GetAsync($"{baseUrl}?symbol={stock.Symbol}");
            if (getResponse.IsSuccessStatusCode)
            {
                var getResponseContent = await getResponse.Content.ReadAsStringAsync();
                var existingStocks = JsonConvert.DeserializeObject<List<StockDto>>(getResponseContent);

                // Find the stock with the same symbol and name
                var existingStock = existingStocks?.FirstOrDefault(s => s.Symbol == stock.Symbol && s.Name == stock.Name);

                if (existingStock != null)
                {
                    // Stock exists, so update it using its ID
                    var updateStock = new UpdateStockRequestDto
                    {
                        Id = existingStock.Id,
                        Symbol = stock.Symbol,
                        Name = stock.Name,
                        Price = stock.Price
                    };
                    var updateContent = new StringContent(JsonConvert.SerializeObject(updateStock), Encoding.UTF8, "application/json");
                    var putUrl = $"{baseUrl}/{existingStock.Id}";
                    var putResponse = await client.PutAsync(putUrl, updateContent);

                    if (!putResponse.IsSuccessStatusCode)
                    {
                        var errorContent = await putResponse.Content.ReadAsStringAsync();
                        _logger.LogWarning($"Failed to update price for {stock.Symbol}: {putResponse.ReasonPhrase}. Error details: {errorContent}");
                    }
                }
                else
                {
                    // Stock does not exist, so create it
                    var postContent = new StringContent(JsonConvert.SerializeObject(stock), Encoding.UTF8, "application/json");
                    var postResponse = await client.PostAsync(baseUrl, postContent);

                    if (!postResponse.IsSuccessStatusCode)
                    {
                        _logger.LogWarning($"Failed to post data for {stock.Symbol}: {postResponse.ReasonPhrase}");
                    }
                }
            }
            else
            {
                _logger.LogWarning($"Failed to get stock information for {stock.Symbol}: {getResponse.ReasonPhrase}");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"An error occurred while processing {stock.Symbol}: {ex.Message}");
        }
    }
}

}
