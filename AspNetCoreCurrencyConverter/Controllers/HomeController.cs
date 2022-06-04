using AspNetCoreCurrencyConverter.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetCoreCurrencyConverter.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new HomeViewModel
            {
                SelectedFromCurrencyId = 0,
                SelectedToCurrencyId = 2,
                Currencies = GetFakeCurrencies()
            });
        }

        private IEnumerable<SelectListItem> GetFakeCurrencies()
        {
            var currencies = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Value = "0",
                    Text = "USD"
                },
                new SelectListItem
                {
                    Value = "1",
                    Text = "EUR"
                },
                new SelectListItem
                {
                    Value = "2",
                    Text = "RUB"
                }
            };

            return new SelectList(currencies, "Value", "Text");
        }
    }
}
