using KysectAcademyTask.FileComparer.Interfaces;
using KysectAcademyTask.FileComparer.Models;

namespace KysectAcademyTask.FileComparer.Filters;

public class WhiteAndBlackListFilter : IFilter
{
        
    public List<Submit> GetWhiteSubmits(List<Submit> submits, IReadOnlyCollection<string> authorWhiteList)
    {
        List<Submit> whiteSubmits = new();
        foreach (Submit submit in submits)
        {
            if (authorWhiteList.Contains(submit.StudentName))
            {
                whiteSubmits.Add(submit);
            }
        }

        return whiteSubmits;
    }

    public void GetSubmitsWithoutIgnoredStudents(List<Submit> submits, IReadOnlyCollection<string> authorBlackList)
    {
        var toDeleteElements = new List<int>();
        for (int i = 0; i < submits.Count; i++)
        {
            if (authorBlackList.Contains(submits[i].StudentName))
            {
                toDeleteElements.Add(i);
            }
        }

        foreach (int index in toDeleteElements)
        {
            submits.RemoveAt(index);
        }
            
    }
}