namespace CurrencyConverterCore.Services
{
    internal class CurrencySymbolsResponse
    {
        public class Rootobject
        {
            public Motd Motd { get; set; }
            public bool Success { get; set; }
            public Dictionary<string, SymbolItem> Symbols { get; set; }
        }

        public class Motd
        {
            public string Msg { get; set; }
            public string Url { get; set; }
        }

        public class SymbolItem
        {
            public string Description { get; set; }
            public string Code { get; set; }
        }
    }
}