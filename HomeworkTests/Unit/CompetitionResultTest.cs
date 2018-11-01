using Homework.Models;
using Homework.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeworkTests.Unit
{
    [TestClass]
    public class CompetitionResultTest
    {
        Array<Application> winnerApplications;
        CompetitionResult result;

        [TestInitialize]
        public void Setup()
        {
            winnerApplications = new Array<Application>(
                new[] { new Application(1, 2, 3, 4), new Application(5, 6, 7, 8) }
            );
            result = new CompetitionResult(winnerApplications);
        }

        [TestMethod]
        public void ItHasTheWinnerApplications()
        {
            Assert.AreEqual(winnerApplications, result.WinnerApplications);
        }

        [TestMethod]
        public void ItCanCalculateTheProfit()
        {
            Assert.AreEqual(12, result.Profit);
        }
    }
}
