using System.Collections.Generic;

namespace KysectAcademyTask.FileComparer
{
    public interface IResearcher
    {
        List<Submit> Research(string inputPath, List<string> directoryBlackList);
    }
}