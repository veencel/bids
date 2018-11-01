using Homework.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeworkTests.Unit
{
    [TestClass]
    public class ApplicationTest
    {
        Application competition;

        [TestInitialize]
        public void Setup()
        {
            competition = new Application(1, 2, 4, 100);
        }

        [TestMethod]
        public void ItCanBeCreatedFromAString()
        {
            var application = new Application(1, "10 20 30");

            Assert.AreEqual(1, application.Identifier);
            Assert.AreEqual(10, application.StartParcelNumber);
            Assert.AreEqual(20, application.EndParcelNumber);
            Assert.AreEqual(30, application.Price);
        }

        [TestMethod]
        public void ItCanCheckEquality()
        {
            var same = competition;
            var other = new Application(2, 3, 6, 120);

            Assert.IsTrue(competition.Is(same));
            Assert.IsFalse(competition.Is(other));
            Assert.IsFalse(same.Is(other));
        }

        [TestMethod]
        public void ItCanCheckIntersection()
        {
            Assert.IsTrue(competition.Intersects(new Application(2, 3, 5, 1)));
            Assert.IsTrue(competition.Intersects(new Application(2, 1, 3, 1)));
            Assert.IsTrue(competition.Intersects(new Application(2, 1, 10, 1)));
            Assert.IsTrue(competition.Intersects(new Application(2, 1, 2, 1)));
            Assert.IsTrue(competition.Intersects(new Application(2, 4, 4, 1)));
            Assert.IsTrue(competition.Intersects(new Application(2, 2, 2, 1)));

            Assert.IsFalse(competition.Intersects(new Application(2, 1, 1, 1)));
            Assert.IsFalse(competition.Intersects(new Application(2, 5, 8, 1)));
        }
    }
}
