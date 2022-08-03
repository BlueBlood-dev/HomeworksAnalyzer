using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using KysectAcademyTask.DatabaseLayer;
using KysectAcademyTask.DatabaseLayer.Entities;
using KysectAcademyTask.FileComparer.Comparators;
using KysectAcademyTask.FileComparer.Interfaces;
using KysectAcademyTask.FileComparer.Models;
using Microsoft.EntityFrameworkCore;


namespace KysectAcademyTask.FileComparer
{
    public class ComparingWithoutDatabaseUpload : ISubmitsComparerLogic
    {


        private int FindSubmitIdAndAddResult(double result, Submit whSubmit, Submit submit)
        {
            using DataBaseContext db = new DataBaseBuilder().Build();
            List<Student> students = db.Student.Include(s => s.Submissions).ToList();
            throw new NotImplementedException();
        }
    
        
        
        
        
        public void ComparingProcess(List<Submit> submits, List<Submit> whiteSubmits, IComparator comparator,
            IWriter writer, string outputPath, string inputPath)
        {
            int amountOfCmp = submits.Count * whiteSubmits.Count;
            int counter = 1;
            SubmitsComparer comparer = new();
            DirectorySubmitPathGetter getter = new();

            foreach (Submit whSubmit in whiteSubmits)
            {
                foreach (Submit submit in submits)
                {
                    if (whSubmit.HomeworkName.Equals(submit.HomeworkName) &&
                        !whSubmit.StudentName.Equals(submit.StudentName))
                    {
                        double compareSubmitsResult = comparer.CompareSubmits(whSubmit, submit,
                            new(getter.GetSubmitPath(whSubmit, inputPath)),
                            new DirectoryInfo(getter.GetSubmitPath(submit, inputPath)), writer, comparator, outputPath);
                    }

                    Console.WriteLine($"{counter++}\\{amountOfCmp}");
                }
            }
        }
    }
}