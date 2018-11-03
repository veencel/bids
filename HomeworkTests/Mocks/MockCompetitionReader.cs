using Homework.Interfaces;
using Homework.Models;
using Homework.Utils;

namespace HomeworkTests.Mocks
{
    class MockCompetitionReader: IApplicationsReader
    {
        Array<Application> _applications;

        public MockCompetitionReader(Array<Application> applications)
        {
            _applications = applications;
        }

        public Array<Application> Read()
        {
            return _applications;
        }
    }
}
