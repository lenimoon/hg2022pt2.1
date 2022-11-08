
namespace EierfarmBl
{
    public class Chicken
    {
        public Chicken(string name)
        {
            this.Name = name;
            this.Weight = 1000;
            this.HatchDate = DateTime.Today.AddDays(-140);
        }

        public List<Egg> Eggs { get; set; }=new List<Egg>();
        public double Weight { get; set; }
        public string Name { get; set; }
        public DateTime HatchDate { get; set; }

        public void LayEgg()
        {
            if (this.Weight > 1500)
            {
                Egg egg = new Egg(this);
                this.Eggs.Add(egg);
                this.Weight -= egg.Weight;
            }
        }

        public void Eat()
        {
            if (this.Weight < 3000)
            {
                // this.Weight = this.Weight + 100
                this.Weight += 100;
            }
        }
    }
}
