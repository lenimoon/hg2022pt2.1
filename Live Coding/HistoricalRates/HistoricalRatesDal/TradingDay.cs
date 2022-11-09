using System.Globalization;
using System.Xml.Linq;

namespace HistoricalRatesDal
{
    public class TradingDay
    {
        public TradingDay(XElement tradingDayNode)
        {
            this.Date = Convert.ToDateTime(tradingDayNode.Attribute("time").Value);

            CultureInfo ciEzb = new CultureInfo("en-US");
            NumberFormatInfo nfiEzb = ciEzb.NumberFormat;
            //NumberFormatInfo nfiEzb = new NumberFormatInfo() { NumberDecimalSeparator = "." };

            var qCurrencies = tradingDayNode.Elements()
                                            .Select(xe => new Currency()
                                            {
                                                EuroRate = Convert.ToDouble(xe.Attribute("rate").Value, nfiEzb),
                                                Symbol = xe.Attribute("currency").Value
                                            });

            this.Currencies=qCurrencies.ToList();
        }

        public DateTime Date { get; set; }

        private List<Currency> currencies;

        public List<Currency> Currencies
        {
            get { return currencies; }
            set { currencies = value; }
        }

    }
}