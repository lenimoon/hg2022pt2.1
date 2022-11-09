using HistoricalRatesDal;

namespace HistoricalRatesUnitTests
{
    public class Tests
    {
        string url;

        [SetUp]
        public void Setup()
        {
            url = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-hist-90d.xml";
        }

        [Test]
        public void IsArchiveInitializing()
        {
            Archive archive = new Archive(url);

            Assert.AreEqual(CountAttribute("time"), archive.TradingDays.Count);
        }

        [Test]
        public void GetUSD()
        {
            Archive archive = new Archive(url);

            Currency? usd = archive.TradingDays?.FirstOrDefault()?.Currencies?.FirstOrDefault();
            Console.WriteLine($"USD: {usd?.EuroRate}");

            Assert.AreEqual(1.0039, usd?.EuroRate);
        }

        private double CountAttribute(string attributeName)
        {
            // TODO: Ausprogrammieren
            return 64;
        }
    }
}