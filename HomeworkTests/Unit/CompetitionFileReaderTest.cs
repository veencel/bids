using Homework.Implementations;
using Homework.Models;
using Homework.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeworkTests.Unit
{
    [TestClass]
    public class CompetitionFileReaderTest
    {
        CompetitionFileReader reader;

        [TestInitialize]
        public void Setup()
        {
            reader = new CompetitionFileReader("Resources/TEST.INPUT");
        }

        [TestMethod]
        public void ItCanReadTheApplicationsFromAFile()
        {
            var applications = reader.Read();

            Assert.AreEqual(2, applications.Length);

            Assert.AreEqual(1, applications[0].Identifier);
            Assert.AreEqual(1, applications[0].StartParcelNumber);
            Assert.AreEqual(5, applications[0].EndParcelNumber);
            Assert.AreEqual(10000, applications[0].Price);

            Assert.AreEqual(2, applications[1].Identifier);
            Assert.AreEqual(2, applications[1].StartParcelNumber);
            Assert.AreEqual(3, applications[1].EndParcelNumber);
            Assert.AreEqual(50000, applications[1].Price);
        }
    }
}
