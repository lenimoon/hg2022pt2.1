

using System.Text;

namespace EierfarmUnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsChickenEating()
        {
            Chicken chicken = new Chicken("Hilde");

            double before = chicken.Weight;

            chicken.Eat();

            double after = chicken.Weight;

            Assert.IsTrue(before < after);
            //Assert.AreEqual(before + 100, after);
        }

        [Test]
        public void IsChickenLayingEgg()
        {
            Chicken chicken = new Chicken("Hilde") { Weight = 1550 };

            //chicken.Weight = 1550;

            chicken.LayEgg();

            Assert.AreEqual(1, chicken.Eggs.Count);

        }

        [Test]
        public void IsGooseEating()
        {
            Goose goose = new Goose("Gerda");

            double before = goose.Weight;

            goose.Eat();

            double after = goose.Weight;

            Assert.IsTrue(before < after);

        }

        [Test]
        public void IsChickenWeightFiringEvent()
        {
            Chicken chicken = new Chicken("Chicken");

            chicken.PropertyChanged += this.Chicken_PropertyChanged;

            chicken.Name = "Hilde";
            chicken.Weight = 1234;

            chicken.Eat();
        }

        private void Chicken_PropertyChanged(object? sender, BirdEventArgs e)
        {
            Console.WriteLine($"Die Property {e.ChangedProperty} von {((Chicken)sender).Name} hat PropertyChanged ausgelöst.");

        }
    }
}