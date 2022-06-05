using CurrencyConverterCore.Models;
using System.Text.Json;

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
            var request = new HttpRequestMessage(HttpMethod.Post,
                $"https://openexchangerates.org/api/currencies.json");

            var response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var currenciesNamesResult = await JsonSerializer.DeserializeAsync<CurrenciesNamesResponse>(responseStream);


            var list = new List<Currency>();
            foreach (var prop in currenciesNamesResult.GetType().GetProperties())
            {
                list.Add(new Currency
                {
                    Code = prop.Name,
                    Name = (string)prop.GetValue(currenciesNamesResult, null)
                });
            }

            return list;
        }


        public async Task<string> GetCurrencyRates(string currencyCode)
        {
            //var request = new HttpRequestMessage(HttpMethod.Post,
            //    $"https://api.exchangerate.host/latest");

            //var response = await httpClient.SendAsync(request);

            //response.EnsureSuccessStatusCode();

            //using var responseStream = await response.Content.ReadAsStreamAsync();
            //var exchangeRateResult = await JsonSerializer.DeserializeAsync<ExchangeRateResponse>(responseStream);

            return "foo";
        }
    }
}
