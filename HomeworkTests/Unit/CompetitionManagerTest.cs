using Homework;
using Homework.Models;
using Homework.Utils;
using HomeworkTests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeworkTests.Unit
{
    [TestClass]
    public class CompetitionManagerTest
    {
        MockCompetitionReader reader;
        MockCompetitionResultWriter writer;
        CompetitionManager manager;

        [TestInitialize]
        public void Setup()
        {
            var applications = new Array<Application>(new[] {
                new Application(1, 1, 5, 10000),
                new Application(2, 2, 3, 5000),
                new Application(3, 4, 5, 5000),
                new Application(4, 4, 4, 6000),
            });

            reader = new MockCompetitionReader(applications);
            writer = new MockCompetitionResultWriter();

            manager = new CompetitionManager(reader, writer);
        }

        [TestMethod]
        public void ItCanExecuteACompetition()
        {
            manager.Execute();

            var result = writer.Result;

            Assert.AreEqual(2, result.WinnerApplications.Length);
            Assert.AreEqual(2, result.WinnerApplications[0].Identifier);
            Assert.AreEqual(4, result.WinnerApplications[1].Identifier);
            Assert.AreEqual(11000, result.Profit);
        }
    }
}
