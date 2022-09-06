using KysectAcademyTask.FileComparer.Models;

namespace KysectAcademyTask.FileComparer.Interfaces;

public interface IFilter
{
    List<Submit> GetWhiteSubmits(List<Submit> submits, List<string> authorWhiteList);

    void  GetSubmitsWithoutIgnoredStudents(List<Submit> submits, List<string> authorBlackList);
}