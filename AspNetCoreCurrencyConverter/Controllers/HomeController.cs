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
        private IEnumerable<SelectListItem> currencies;

        public HomeController(IExchangeRateService exchangeService)
        {
            this.exchangeService = exchangeService;
            currencies = GetCurrenciesAsync().Result ?? new List<SelectListItem>();
        }
        public IActionResult Index()
        {
            return View(new HomeViewModel()
            {
                FromSelectedCode = "USD",
                ToSelectedCode = "RUB",
                Currencies = currencies
            });
        }

        [HttpPost]
        [Route("Swap")]
        public IActionResult Swap(HomeViewModel model)
        {
            var newModel = new HomeViewModel()
            {
                FromSelectedCode = model.ToSelectedCode,
                ToSelectedCode = model.FromSelectedCode,
                Currencies = currencies
            };

            ModelState.Clear();

            return View("Index", newModel);
        }

        private async Task<IEnumerable<SelectListItem>> GetCurrenciesAsync()
        {

            var currencies = new List<SelectListItem>();

            foreach (Currency currency in await exchangeService.GetCurrenciesNames())
            {
                currencies.Add(new SelectListItem
                {
                    Value = currency.Code,
                    Text = $"{currency.Code} - {currency.Name}"
                });
            }

            return new SelectList(currencies, "Value", "Text");
        }
    }
}
