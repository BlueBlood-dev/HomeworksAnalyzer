using System.Collections.Generic;

namespace KysectAcademyTask.FileComparer
{
    public class WhiteAndBlackListFilter : IFilter
    {
        
        public List<Submit> GetWhiteSubmits(List<Submit> submits, List<string> authorWhiteList)
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

        public void  GetSubmitsWithoutIgnoredStudents(List<Submit> submits, List<string> authorBlackList)
        {
            List<int> toDeleteElements = new List<int>();
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
}