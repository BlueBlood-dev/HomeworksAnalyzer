using KysectAcademyTask.FileComparer.Interfaces;
using KysectAcademyTask.FileComparer.Models;

namespace KysectAcademyTask.FileComparer;

public class DirectorySubmitPathGetter : IPathGetter
{
    public string GetSubmitPath(Submit submit, string inputPath) 
        => Path.Combine(inputPath, submit.GroupName, submit.StudentName, submit.HomeworkName, submit.SubmitName);
}