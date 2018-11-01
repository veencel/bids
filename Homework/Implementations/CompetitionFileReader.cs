using Homework.Interfaces;
using Homework.Models;
using Homework.Utils;
using System.IO;

namespace Homework.Implementations
{
    public class CompetitionFileReader: ICompetitionReader
    {
        string _path;

        public CompetitionFileReader(string path)
        {
            _path = path;
        }

        public Array<Application> Read()
        {
            Array<string> lines = new Array<string>(File.ReadAllLines(_path));

            lines.PopFirst();

            int counter = 1;

            return lines.Map((string line) => new Application(counter++, line));
        }
    }
}
