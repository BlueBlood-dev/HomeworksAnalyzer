using KysectAcademyTask.FileComparer.Interfaces;
using KysectAcademyTask.FileComparer.Models;

namespace KysectAcademyTask.FileComparer.FileSystemResearchers;

public class DirectoryResearcher : IResearcher
{
    private bool CheckIfDirectoryNotIgnored(List<string> directoryBlackList, string studentName, string groupName,
        string homeworkName, string submitName)
    {
        return !directoryBlackList.Contains(studentName) && !directoryBlackList.Contains(groupName) &&
               !directoryBlackList.Contains(homeworkName) && !directoryBlackList.Contains(submitName);
    }

    public List<Submit> Research(string inputPath, IReadOnlyCollection<string> directoryBlackList)
    {
        var list = new List<Submit>();
        var groups = new DirectoryInfo(inputPath);

        foreach (DirectoryInfo group in groups.GetDirectories())
        {
            foreach (DirectoryInfo students in group.GetDirectories())
            {
                foreach (DirectoryInfo homeworks in students.GetDirectories())
                {
                    foreach (DirectoryInfo submits in homeworks.GetDirectories())
                    {
                        if (CheckIfDirectoryNotIgnored(new List<string>(directoryBlackList), students.Name, group.Name,
                                homeworks.Name, submits.Name))
                        {
                            list.Add(new Submit(group.Name, students.Name, homeworks.Name, submits.Name));
                        }
                    }
                }
            }
        }
        return list;
    }
}