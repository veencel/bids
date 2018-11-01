using Homework.Models;
using Homework.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeworkTests.Unit
{
    [TestClass]
    public class CombinationTest
    {
        [TestMethod]
        public void ItHasApplications()
        {
            var applications = new Array<Application>(new[] { new Application() });
            var combination = new Combination(applications);

            Assert.AreEqual(applications, combination.Applications);
        }

        [TestMethod]
        public void ItCanAddAnApplicationIntoTheCombination()
        {
            var application = new Application(1, 2, 3, 4);
            var otherApplication = new Application(2, 5, 7, 8);

            var combination = new Combination(new Array<Application>(new[] { application }));

            combination.Add(otherApplication);

            Assert.AreEqual(otherApplication, combination.Applications[1]);
        }

        [TestMethod]
        public void ItCanCheckIfItContainsAnApplication()
        {
            var application = new Application(1, 2, 3, 4);
            var otherApplication = new Application(2, 5, 7,8);

            var combination = new Combination(new Array<Application>(new []{ otherApplication }));

            Assert.IsFalse(combination.Contains(application));

            combination = new Combination(new Array<Application>(new[] { application, otherApplication }));

            Assert.IsTrue(combination.Contains(application));
        }

        [TestMethod]
        public void ItCanCheckIntersection()
        {
            var application = new Application(1, 2, 3, 4);

            var intersectingApplication1 = new Application(2, 3, 3, 10);
            var intersectingApplication2 = new Application(3, 2, 2, 10);

            var independentApplication1 = new Application(4, 4, 6, 10);
            var independentApplication2 = new Application(5, 7, 10, 10);

            var combination = new Combination(new Array<Application>(new[] { independentApplication1, independentApplication2 }));

            Assert.IsFalse(combination.Intersects(application));

            combination = new Combination(new Array<Application>(new[] { intersectingApplication1, intersectingApplication2 }));

            Assert.IsTrue(combination.Intersects(application));
        }
    }
}
