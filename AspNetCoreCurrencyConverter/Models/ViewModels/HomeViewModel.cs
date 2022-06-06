using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;

namespace AspNetCoreCurrencyConverter.ViewModels
{
    public class HomeViewModel
    {
        public double Amount { get; set; }
        public double Rate { get; set; }

        public string OneUnitFromRate => Format(Math.Round(Amount * Rate, 4));
        public string OneUnitToRate => Format(Math.Round(Amount / Rate, 4));
        public string FromSelectedCode { get; set; }
        public string ToSelectedCode { get; set; }
        public IEnumerable<SelectListItem> Currencies { get; set; } = new List<SelectListItem>();

        public string Format(double value)
        {
            var nfi = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();
            nfi.NumberGroupSeparator = " ";
            return value.ToString("#,0.###", nfi);
        }

    }
}
