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
    public class ComparingWithDatabaseUpload : ISubmitsComparerLogic
    {
        public void ComparingProcess(List<Submit> submits, List<Submit> whiteSubmits, IComparator comparator,
            IWriter writer, string outputPath,
            string inputPath)
        {
            using DataBaseContext db = new DataBaseBuilder().Build();
            var dataBaseInitializer = new DataBaseInitializer();
            ICollection<ResultOfCompare> resultOfCompares = new List<ResultOfCompare>();
             if (db.Student.ToList().Count == 0 || db.Submissions.ToList().Count == 0)
             {
                 dataBaseInitializer.Initialize(submits,db);
             }
             
             foreach (Submit whiteSubmit in whiteSubmits)
            {
                foreach (Submit submit in submits)
                {
                    int firstStudentId = dataBaseInitializer.FindStudentId(whiteSubmit.StudentName, db);
                    int secondStudentId = dataBaseInitializer.FindStudentId(whiteSubmit.StudentName, db);
                    
                    int firstSubmissionId = dataBaseInitializer.FindSubmissionId(firstStudentId,db);
                    int secondSubmissionId = dataBaseInitializer.FindSubmissionId(secondStudentId,db);

                    if (!new UniqueValueController().CheckIfResultExists(firstSubmissionId, secondSubmissionId,db) &&
                        submit.HomeworkName == whiteSubmit.HomeworkName &&
                        submit.StudentName != whiteSubmit.StudentName)
                    {
                        double result = new SubmitsComparer().CompareSubmits(whiteSubmit, submit,
                            new DirectoryInfo(new DirectorySubmitPathGetter().GetSubmitPath(whiteSubmit, inputPath)),
                            new DirectoryInfo(new DirectorySubmitPathGetter().GetSubmitPath(submit, inputPath)), writer,
                            comparator,
                            outputPath);
                        resultOfCompares.Add(new ResultOfCompare(firstSubmissionId, secondSubmissionId, result));
                    }
                }
            }
            Console.WriteLine("SAVING THE RESULT");
            new DataBaseSaver().Save(resultOfCompares, db);
        }
    }
}