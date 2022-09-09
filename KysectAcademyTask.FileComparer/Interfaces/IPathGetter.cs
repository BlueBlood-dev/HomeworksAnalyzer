using KysectAcademyTask.FileComparer.Models;

namespace KysectAcademyTask.FileComparer.Interfaces;

public interface IPathGetter
{
    string GetSubmitPath(Submit submit, string inputPath);
}