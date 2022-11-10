

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
    }
}