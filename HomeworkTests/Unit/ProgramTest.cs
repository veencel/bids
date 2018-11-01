using System.IO;
using Homework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeworkTests.Unit
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void ItExecutesTheCompetition()
        {
            Program.Main(new string[0]);

            Assert.IsTrue(File.Exists("./LICIT.KI"));
        }
    }
}
