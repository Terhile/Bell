using Invoices.API.Models.ResponseModels;
using Microsoft.Net.Http.Headers;
using System.Globalization;

namespace Invoices.API.HttpClients
{
    public class AssetsManagerServiceClient
    {
        private readonly HttpClient _httpClient;

        public AssetsManagerServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://host.docker.internal:8018/");
            _httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
        }

        public async Task<IEnumerable<AssetResponseModel>?> InvoiceByDate(DateTime dateTime)
        {
            var assets = await _httpClient.GetFromJsonAsync<IEnumerable<AssetResponseModel>>($"assets/{dateTime.Date.ToString("yyyy-MM-dd")}");
            return assets;
        }
    }
}
