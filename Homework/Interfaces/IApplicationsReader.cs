using Homework.Models;
using Homework.Utils;

namespace Homework.Interfaces
{
    public interface IApplicationsReader
    {
        Array<Application> Read();
    }
}
