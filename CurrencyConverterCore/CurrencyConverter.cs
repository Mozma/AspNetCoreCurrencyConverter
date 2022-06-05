using CurrencyConverterCore.Models;

namespace CurrencyConverterCore
{
    public static class CurrencyConverter
    {
        public static List<Currency> GetFakeCurrencies()
        {
            return new List<Currency>() {
                new Currency
                {
                    Code = "0",
                    Name = "USD"
                },
                new Currency
                {
                    Code = "1",
                    Name = "EUR"
                },
                new Currency
                {
                    Code = "2",
                    Name = "RUB"
                }
            };
        }
    }
}