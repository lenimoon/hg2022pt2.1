using System.Xml.Serialization;

namespace EierfarmBl
{
    public class Egg
    {
        private Egg() { }

        // Konstruktor für eine Ei-Instanz
        public Egg(IEggProducer mother)
        {
            this.Mother = mother;

            Random random = new Random();
            //_weight = random.Next(45, 81);
            this.Weight = random.Next(45, 81);
            //this.Id = Guid.NewGuid(); // ersetzt durch Autop-Property-Initializer
            this.Color = (EggColor)random.Next(Enum.GetNames(typeof(EggColor)).Length);
        }

        // Backing Field für die Weight-Property
        private double _weight;

        public double Weight
        {
            get { return _weight; } // var w = myEgg.Weight;
            set
            {
                if (value > 0)
                {
                    _weight = value;
                }
            } // myEgg.Weight = 64;
        }

        // Öffentliches Feld
        //public double Weight2;

        // Auto-Property
        // Property mit (durch den Compiler) autom. generiertem Backing Field
        public Guid Id { get; set; } = Guid.NewGuid(); // Auto-Property-Initializer

        [XmlAttribute("Colour")]
        public EggColor Color { get; set; }

        public DateTime LayingDate { get; set; }

        [XmlIgnore]
        public IEggProducer Mother { get; set; }

    }

    public enum EggColor
    {
        Green,
        Light,
        Dark
    }
}