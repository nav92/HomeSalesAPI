using NUnit.Framework;
using VeArc_HomeSalesAPI.Controllers;
using Moq;

namespace VeArc_HomeSalesAPITest
{
    public class HomeSalesControllerTest
    {
        HomeSalesController controller;
        [SetUp]
        public void Setup()
        {
            controller = new HomeSalesController();
        }

        [Test]
        [TestCase(2017, 03)]
        public void GetDistinctSchools_Test(int year, int month)
        {
            var result = controller.GetDistinctSchools(year, month);
            Assert.IsTrue(result.Count > 0);
        }

        [Test]
        [TestCase("South Park", 2017, 03)]
        public void GetAverageNumberOfDays_Test(string schoolName, int year, int month)
        {
            var result = controller.GetAverageNumberOfDays(schoolName, year, month);
            Assert.AreEqual(16, result);
        }
    }
}