using Homework.Utils;

namespace Homework.Models
{
    public struct CompetitionResult
    {
        public Array<Application> WinnerApplications { get; }

        public int Profit
        {
            get
            {
                return WinnerApplications
                    .Reduce((application, carry) => carry + application.Price, 0);
            }
        }

        public CompetitionResult(Array<Application> winnerApplications)
        {
            this.WinnerApplications = winnerApplications;
        }
    }
}
