using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetCoreCurrencyConverter.ViewModels
{
    public class HomeViewModel
    {
        public string FromSelectedCode { get; set; }
        public string ToSelectedCode { get; set; }
        public IEnumerable<SelectListItem> Currencies { get; set; } = new List<SelectListItem>();
    }
}
