using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace EierfarmBl
{
    public interface IEggProducer
    {
        ObservableCollection<Egg> Eggs { get; set; }
        double Weight { get; set; }

        void LayEgg();
    }
}