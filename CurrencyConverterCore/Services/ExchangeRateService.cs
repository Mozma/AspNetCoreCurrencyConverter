using CurrencyConverterCore.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CurrencyConverterCore.Services
{
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly HttpClient httpClient;
        public ExchangeRateService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Currency>> GetCurrenciesNames()
        {
            var url = $"https://api.exchangerate.host/symbols";

            var response = await DeserializeToObjectAsync<CurrencySymbolsResponse.Rootobject>(url);

            var list = new List<Currency>();
            foreach (var prop in response.Symbols)
            {
                list.Add(new Currency
                {
                    Code = prop.Value.Code,
                    Name = prop.Value.Description
                });
            }

            return list;
        }

        public async Task<double> GetCurrencyRates(decimal amount, string fromCurrency, string toCurrency)
        {
            var url = $"https://api.exchangerate.host/convert?from={fromCurrency}&to={toCurrency}&amount={amount}";

            var response = await DeserializeToObjectAsync<ConvertResponse.Rootobject>(url);

            return response.Info.Rate;
        }

        private async Task<T> DeserializeToObjectAsync<T>(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;
            options.Converters.Add(new JsonStringEnumConverter());

            var result = await JsonSerializer.DeserializeAsync<T>(responseStream, options);

            return result;
        }
    }
}
