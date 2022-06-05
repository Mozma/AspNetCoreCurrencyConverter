using AspNetCoreCurrencyConverter.ViewModels;
using CurrencyConverterCore.Models;
using CurrencyConverterCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetCoreCurrencyConverter.Controllers
{
    public class HomeController : Controller
    {
        private IExchangeRateService exchangeService;

        public HomeController(IExchangeRateService exchangeService)
        {
            this.exchangeService = exchangeService;
        }

        public async Task<IActionResult> Index()
        {
            return View(new HomeViewModel
            {
                SelectedFromCurrencyId = 0,
                SelectedToCurrencyId = 2,
                Currencies = await GetCurrenciesAsync()
            });
        }

        private async Task<IEnumerable<SelectListItem>> GetCurrenciesAsync()
        {
            var currencies = new List<SelectListItem>();

            foreach (Currency currency in await exchangeService.GetCurrenciesNames())
            {
                currencies.Add(new SelectListItem
                {
                    Value = currency.Code,
                    Text = currency.Name
                });
            }

            return new SelectList(currencies, "Value", "Text");
        }
    }
}
