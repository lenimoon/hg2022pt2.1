using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EierfarmBl
{
    public class Goose : Bird
    {
        public Goose() : base("New Goose")
        {
            this.Weight = 2500;
        }

        public Goose(string name) : this()
        {
           this.Name = name;
        }

        public int Steuerkurs { get; set; }

        public override void Eat()
        {

            if (this.Weight < 5000)
            {
                this.Weight += 250;
            }
        }

        public override void LayEgg()
        {
            if (this.Weight > 2000)
            {
                Egg egg = new Egg(this);
                this.Weight -= egg.Weight;
                this.Eggs.Add(egg);

            }
        }
    }
}