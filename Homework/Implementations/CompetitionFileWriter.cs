using Homework.Interfaces;
using Homework.Models;
using System.IO;

namespace Homework.Implementations
{
    public class CompetitionResultFileWriter: ICompetitionResultWriter
    {
        string _path;

        public CompetitionResultFileWriter(string path)
        {
            _path = path;
        }

        public void Write(CompetitionResult result)
        {
            string[] identifiers = result.WinnerApplications
                .Map((application) => application.Identifier.ToString())
                .All();

            File.WriteAllLines(_path, new[] { result.Profit.ToString(), string.Join(" ", identifiers) });
        }
    }
}
