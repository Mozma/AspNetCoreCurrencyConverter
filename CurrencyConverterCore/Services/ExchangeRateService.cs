using CurrencyConverterCore.Models;
using System.Text;
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


        public async Task<double> GetCurrencyRates(double amount, string from, string to)
        {
            //var request = new HttpRequestMessage(HttpMethod.Post,
            //     $"https://openexchangerates.org/api/convert/{amount}/{from}/{to}?app_id=458db32e2d1a4181ab9f6f5f1623a8a7");

            //var response = await httpClient.SendAsync(request);

            //response.EnsureSuccessStatusCode();

            //using var responseStream = await response.Content.ReadAsStreamAsync();
            //var currenciesNamesResult = await JsonSerializer.DeserializeAsync<ExchangeRateResponse.Rootobject>(responseStream);


            //foreach (var item in currenciesNamesResult.rates.GetType().GetProperties())
            //{
            //    if (item.Name.Equals(to))
            //    {
            //        return (double)item.GetValue(currenciesNamesResult, null);
            //    }
            //}

            return 1;
        }
    }
}
