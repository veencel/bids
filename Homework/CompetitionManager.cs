using Homework.Interfaces;
using Homework.Models;
using Homework.Utils;

namespace Homework
{
    public class CompetitionManager
    {
        private readonly IApplicationsReader _reader;
        private readonly ICompetitionResultWriter _writer;

        public CompetitionManager(IApplicationsReader reader, ICompetitionResultWriter writer)
        {
            _reader = reader;
            _writer = writer;
        }

        public void Execute()
        {
            var applications = _reader.Read();

            var combination = DetermineWinnerCombination(applications);

            _writer.Write(new CompetitionResult(combination.Applications));
        }

        private Combination DetermineWinnerCombination(Array<Application> applications)
        {
            var combinations = GetCombinations(applications);

            return combinations.Max((Combination combination, Combination max) =>
            {
                int SumProfit(Application application, int carry)
                {
                    return carry + application.Price;
                }

                return combination.Applications.Reduce(SumProfit, 0) > max.Applications.Reduce(SumProfit, 0);
            });
        }

        private Array<Combination> GetCombinations(Array<Application> applications)
        {
            var combinations = new Array<Combination>();

            foreach (var application in applications)
            {
                combinations.Merge(CreateCombinations(application, applications));
            }

            return combinations;
        }

        private Array<Combination> CreateCombinations(Application application, Array<Application> applications)
        {
            return UnfoldCombination(
                new Combination(new Array<Application>(new[] { application })),
                applications
            );
        }

        private Array<Combination> UnfoldCombination(Combination combination, Array<Application> applications)
        {
            var combinations = new Array<Combination>(new[] { combination });

            foreach (var application in applications)
            {
                if (combination.Contains(application) || combination.Intersects(application))
                {
                    continue;
                }

                var newCombination = new Combination(combination).Add(application);
                combinations.Merge(UnfoldCombination(newCombination, applications));
            }

            return combinations;
        }
    }
}
