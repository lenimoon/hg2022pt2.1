using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EierfarmBl
{
    public abstract class Bird : IEggProducer, IDisposable, IBird
    {
        public Bird(string name)
        {
            this.Name = name;
        }

        public List<Egg> Eggs { get; set; } = new List<Egg>();

        public DateTime HatchDate { get; set; }

        public string Name { get; set; }

        public double Weight { get; set; }

        public void Dispose()
        {
            foreach (Egg egg in this.Eggs)
            {
                egg.Mother = null;
            }

            this.Eggs = null;
        }

        public abstract void Eat();

        public abstract void LayEgg();
    }
}