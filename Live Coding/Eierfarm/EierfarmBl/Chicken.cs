
namespace EierfarmBl
{
    public class Chicken : Bird
    {
        private Chicken():base("Neues Huhn") { }

        public Chicken(string name) : base(name)
        {
            this.Name = name;
            this.Weight = 1000;
            this.HatchDate = DateTime.Today.AddDays(-140);
        }

        public override void LayEgg()
        {
            if (this.Weight > 1500)
            {
                Egg egg = new Egg(this);
                this.Eggs.Add(egg);
                this.Weight -= egg.Weight;
            }
        }

        public override void Eat()
        {
            if (this.Weight < 3000)
            {
                // this.Weight = this.Weight + 100
                this.Weight += 100;
            }
        }
    }
}
