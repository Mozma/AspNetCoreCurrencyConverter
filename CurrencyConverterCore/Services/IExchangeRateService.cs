using CurrencyConverterCore.Models;

namespace CurrencyConverterCore.Services
{
    public interface IExchangeRateService
    {
        Task<List<Currency>> GetCurrenciesNames();
        Task<string> GetCurrencyRates(string currencyCode);
    }
}
