namespace HistoricalRatesDal
{
    public class TradingDay
    {
		public DateTime Date { get; set; }

		private List<Currency> currencies;

		public List<Currency> Currencies
		{
			get { return currencies; }
			set { currencies = value; }
		}

	}
}