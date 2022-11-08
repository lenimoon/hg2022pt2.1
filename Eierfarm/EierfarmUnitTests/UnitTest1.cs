

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
    }
}