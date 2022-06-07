using CurrencyConverterCore.Models;

namespace CurrencyConverterCore.Services
{
    public interface IExchangeRateService
    {
        Task<List<Currency>> GetCurrenciesNames();
        Task<double> GetCurrencyRates(double amount, string from, string to);
    }
}
