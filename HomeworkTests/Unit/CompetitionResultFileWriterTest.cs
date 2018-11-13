using System;
using System.IO;
using Homework.Implementations;
using Homework.Models;
using Homework.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeworkTests.Unit
{
    [TestClass]
    public class CompetitionResultFileWriterTest
    {
        string path = "TEST.OUTPUT";
        private CompetitionResult _result;
        private CompetitionResultFileWriter _writer;

        [TestInitialize]
        public void Setup()
        {
            _result = new CompetitionResult(new Array<Application>(new[] {
                new Application(1, 2, 3, 100),
                new Application(2, 4, 10, 200)
            }));

            _writer = new CompetitionResultFileWriter(path);
        }

        [TestCleanup]
        public void TearDown()
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        [TestMethod]
        public void ItCanWriteTheCompetitionResultToAFile()
        {
            _writer.Write(_result);

            string content = File.ReadAllText(path);

            Assert.AreEqual("300" + Environment.NewLine + "1 2" + Environment.NewLine, content);
        }
    }
}
