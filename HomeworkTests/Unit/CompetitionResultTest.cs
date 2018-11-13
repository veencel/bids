using Homework.Models;
using Homework.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeworkTests.Unit
{
    [TestClass]
    public class CompetitionResultTest
    {
        private Array<Application> _winnerApplications;
        private CompetitionResult _result;

        [TestInitialize]
        public void Setup()
        {
            _winnerApplications = new Array<Application>(
                new[] { new Application(1, 2, 3, 4), new Application(5, 6, 7, 8) }
            );
            _result = new CompetitionResult(_winnerApplications);
        }

        [TestMethod]
        public void ItHasTheWinnerApplications()
        {
            Assert.AreEqual(_winnerApplications, _result.WinnerApplications);
        }

        [TestMethod]
        public void ItCanCalculateTheProfit()
        {
            Assert.AreEqual(12, _result.Profit);
        }
    }
}
