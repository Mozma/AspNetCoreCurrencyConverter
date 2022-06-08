namespace CurrencyConverterCore.Services
{
    public class ConvertResponse
    {
        public class Rootobject
        {
            public Motd Motd { get; set; }
            public bool Success { get; set; }
            public Query Query { get; set; }
            public Info Info { get; set; }
            public bool Historical { get; set; }
            public string Date { get; set; }
            public double Result { get; set; }
        }

        public class Motd
        {
            public string Msg { get; set; }
            public string Url { get; set; }
        }

        public class Query
        {
            public string From { get; set; }
            public string To { get; set; }
            public int Amount { get; set; }
        }

        public class Info
        {
            public float Rate { get; set; }
        }
    }
}