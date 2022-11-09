using System.Xml.Linq;

namespace HistoricalRatesDal
{
    public class TradingDay
    {
        public TradingDay(XElement tradingDayNode)
        {

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