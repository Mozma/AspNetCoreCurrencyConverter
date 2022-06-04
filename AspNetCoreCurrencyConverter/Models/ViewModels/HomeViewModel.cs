using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetCoreCurrencyConverter.ViewModels
{
    public class HomeViewModel
    {
        public int SelectedFromCurrencyId { get; set; } = 0;
        public int SelectedToCurrencyId { get; set; } = 0;
        public IEnumerable<SelectListItem> Currencies { get; set; } = new List<SelectListItem>();
    }
}
