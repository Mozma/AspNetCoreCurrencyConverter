using CurrencyConverterCore.Models;

namespace CurrencyConverterCore.Services
{
    public interface IExchangeRateService
    {
        Task<List<Currency>> GetCurrenciesNames();
        Task<double> GetCurrencyRates(decimal amount, string from, string to);
    }
}
