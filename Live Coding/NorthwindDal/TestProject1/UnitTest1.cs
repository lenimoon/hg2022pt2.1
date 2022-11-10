using NorthwindDal.Model;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AreCustomersLoading()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var qGermans = context.Customers.Where(cu => cu.Country == "Germany").Select(cu => new { cu.CompanyName, cu.Orders.Count });

                foreach (var item in qGermans)
                {
                    Console.WriteLine($"{item.CompanyName}: {item.Count}");
                }

                Assert.AreEqual(13, qGermans.Count());
            }
        }
    }
}