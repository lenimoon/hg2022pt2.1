using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EierfarmBl
{
    public interface IEggProducer
    {
        List<Egg> Eggs { get; set; }
        double Weight { get; set; }

        void LayEgg();
    }
}