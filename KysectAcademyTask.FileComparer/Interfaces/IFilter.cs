using System.Collections.Generic;
using KysectAcademyTask.FileComparer.Models;

namespace KysectAcademyTask.FileComparer
{
    public interface IFilter
    {
        List<Submit> GetWhiteSubmits(List<Submit> submits, List<string> authorWhiteList);

       void  GetSubmitsWithoutIgnoredStudents(List<Submit> submits, List<string> authorBlackList);
    }
}