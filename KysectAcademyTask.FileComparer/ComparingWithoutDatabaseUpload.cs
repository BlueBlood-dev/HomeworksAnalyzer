using System;
using System.Collections.Generic;
using KysectAcademyTask.FileComparer.Interfaces;
using KysectAcademyTask.FileComparer.Models;



namespace KysectAcademyTask.FileComparer
{
    public class ComparingWithoutDatabaseUpload : ISubmitsComparerLogic
    {
        public void ComparingProcess(List<Submit> submits, List<Submit> whiteSubmits, IComparator comparator,
            IWriter writer, string outputPath, string inputPath)
        {
            throw new NotImplementedException();
        }
    }
}