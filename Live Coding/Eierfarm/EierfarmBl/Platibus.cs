using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EierfarmBl
{
    public class Platibus : Mammal, IEggProducer
    {
        public List<Egg> Eggs { get; set; }

        public double Weight { get; set; }

        public override void BreastFeed()
        {
            throw new NotImplementedException();
        }

        public void LayEgg()
        {
            if (this.Weight>2500)
            {
                Egg egg = new Egg();
                this.Weight -= egg.Weight;
                this.Eggs.Add(egg);
            }
        }
    }
}