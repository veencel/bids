using Homework.Implementations;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            var competitionManager = new CompetitionManager(
                new CompetitionFileReader(@"./LICIT.BE"),
                new CompetitionResultFileWriter(@"./LICIT.KI")
            );

            competitionManager.Execute();
        }
    }
}
