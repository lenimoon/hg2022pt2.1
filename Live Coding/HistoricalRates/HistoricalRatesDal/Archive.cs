using System.Xml.Linq;

namespace HistoricalRatesDal
{
    /// <summary>
    /// Ein Archiv.
    /// </summary>
    public class Archive
    {
        /// <summary>
        /// Instanziiert ein Archiv mit der gg. URL einer GESMES-XML-Datei
        /// </summary>
        /// <param name="url">Die URL einer GESMES-XML-Datei</param>
        public Archive(string url)
        {
            this.TradingDays = GetData(url);
        }

        /// <summary>
        /// Liest die Daten einer GESMES-XML-Datei (url) und gibt eine Liste
        /// von TradingDays zurück.
        /// </summary>
        /// <param name="url">Die URL einer GESMES-XML-Datei</param>
        /// <returns>Liste mit TradingDay-Objekten</returns>
        private List<TradingDay>? GetData(string url)
        {

            //List<TradingDay> days = new();
            XDocument document = XDocument.Load(url);

            var q = document.Root.Descendants()
                                .Where(xe => xe.Name.LocalName == "Cube"
                                && xe.Attributes().Count() == 1)
                                // Projektion auf TradingDays
                                .Select(xe => new TradingDay(xe));

            return q.ToList();

            //foreach (var item in q)
            //{
            //    TradingDay tradingDay = new TradingDay()
            //    {
            //        Date = Convert.ToDateTime(item.Attribute("time").Value)
            //    };

            //    days.Add(tradingDay);
            //}

            //return days;
        }

        private bool CheckName(XElement xElement, string name)
        {
            if (xElement.Name.LocalName == name)
            {
                return true;
            }
            return false;
        }

        public List<TradingDay>? TradingDays { get; set; } = new List<TradingDay>();


    }
}