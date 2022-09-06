using KysectAcademyTask.FileComparer.Models;

namespace KysectAcademyTask.FileComparer.Interfaces;

public interface IFilter
{
    List<Submit> GetWhiteSubmits(List<Submit> submits, IReadOnlyCollection<string> authorWhiteList);

    void GetSubmitsWithoutIgnoredStudents(List<Submit> submits, IReadOnlyCollection<string> authorBlackList);
}