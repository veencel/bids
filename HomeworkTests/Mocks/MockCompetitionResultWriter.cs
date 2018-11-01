using Homework.Interfaces;
using Homework.Models;

namespace HomeworkTests.Mocks
{
    class MockCompetitionResultWriter : ICompetitionResultWriter
    {
        public CompetitionResult Result { get; private set; }

        public void Write(CompetitionResult result)
        {
            Result = result;
        }
    }
}
