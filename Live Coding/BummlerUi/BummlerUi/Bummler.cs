using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BummlerUi
{
    public class Bummler
    {
        public string Bummeln()
        {
            //Thread.Sleep(5000);
            double b = Wurzelsumme(1e9);
            return $"Fertig mit Bummeln ({b})";
        }

        public string Troedeln()
        {
            double b = Wurzelsumme(2e9);
            return $"Fertig mit Trödeln ({b})";
        }

        public async Task<string> BummelnAsync()
        {
            //Task.Delay(5000);
            double c = await Task.Run(() => Wurzelsumme(1e9)); // Asynchroner Aufruf von Wurzelsumme
            return $"Fertig mit Bummeln ({c:#,##0.00})";
        }

        public async Task<string> TroedelnAsync()
        {
            double c = await Task.Run(() =>
                                            {
                                                double result = 0;

                                                for (int i = 0; i < 2e9; i++)
                                                {
                                                    result += Math.Sqrt(i);
                                                }

                                                return result;
                                            }
                                        );
            return $"Fertig mit Troedeln ({c:#,##0.00})";
        }

        private double Wurzelsumme(double max)
        {
            double result = 0;

            for (int i = 0; i < max; i++)
            {
                result += Math.Sqrt(i);
            }

            return result;
        }
    }
}
