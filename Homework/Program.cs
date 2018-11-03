using Homework.Implementations;

namespace Homework
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var competitionManager = new CompetitionManager(
                new ApplicationsFileReader("LICIT.BE"),
                new CompetitionResultFileWriter("LICIT.KI")
            );

            competitionManager.Execute();
        }
    }
}
