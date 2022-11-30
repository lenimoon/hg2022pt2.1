using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HistoricalRatesUi
{
    public class EuroConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                double betrag = System.Convert.ToDouble(values[0], culture);
                double targetCurrency = System.Convert.ToDouble(values[1], culture);

                return betrag * targetCurrency;
            }
            catch 
            {
                return "Error";
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
