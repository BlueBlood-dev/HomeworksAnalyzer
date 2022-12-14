using KysectAcademyTask.FileComparer.Models;

namespace KysectAcademyTask.FileComparer.Interfaces;

public interface IResearcher
{
    List<Submit> Research(string inputPath, IReadOnlyCollection<string> directoryBlackList);
}