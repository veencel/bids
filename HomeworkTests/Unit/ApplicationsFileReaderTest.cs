using Homework.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeworkTests.Unit
{
    [TestClass]
    public class ApplicationsFileReaderTest
    {
        private ApplicationsFileReader _reader;

        [TestInitialize]
        public void Setup()
        {
            _reader = new ApplicationsFileReader(@"Resources\TEST.INPUT");
        }

        [TestMethod]
        public void ItCanReadTheApplicationsFromAFile()
        {
            var applications = _reader.Read();

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
