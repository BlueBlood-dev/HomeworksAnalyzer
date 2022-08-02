using System.Collections.Generic;
using KysectAcademyTask.FileComparer.Models;

namespace KysectAcademyTask.FileComparer
{
    public interface IResearcher
    {
        List<Submit> Research(string inputPath, List<string> directoryBlackList);
    }
}