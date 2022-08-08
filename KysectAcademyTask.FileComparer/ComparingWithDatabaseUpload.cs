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
            // if (!new DataBaseData(db).CheckIfInitialized())
            // {
            //     //doesn't work
            //     dataBaseInitializer.Initialize(submits,db);
            // }
            dataBaseInitializer.Initialize(submits,db); // should be checked if required
            
            foreach (Submit whiteSubmit in whiteSubmits)
            {
                foreach (Submit submit in submits)
                {
                    
                    int firstStudentId = dataBaseInitializer.FindStudentId(whiteSubmit.StudentName, db);
                    int secondStudentId = dataBaseInitializer.FindStudentId(whiteSubmit.StudentName, db);
                    
                    int firstId = 0;
                    foreach (Submission submission in db.Submissions.ToList().Where(submission => submission.Name == whiteSubmit.SubmitName))
                    {
                        firstId = submission.Id;
                    }
                    //clear db before next checks 
                    //wrong id founders... 
                    var secondSubmissionId = db.Submissions
                        .Where(submission => submission.Name == whiteSubmit.SubmitName).ToList();

                    int secondId = secondSubmissionId[0].Id;
                    Console.WriteLine(firstId);

                    if (!new UniqueValueController().CheckIfResultExists(firstId, secondId,db) &&
                        submit.HomeworkName == whiteSubmit.HomeworkName &&
                        submit.StudentName != whiteSubmit.StudentName)
                    {
                        double result = new SubmitsComparer().CompareSubmits(whiteSubmit, submit,
                            new DirectoryInfo(new DirectorySubmitPathGetter().GetSubmitPath(whiteSubmit, inputPath)),
                            new DirectoryInfo(new DirectorySubmitPathGetter().GetSubmitPath(submit, inputPath)), writer,
                            comparator,
                            outputPath);
                        resultOfCompares.Add(new ResultOfCompare(firstId, secondId, result));
                    }
                }
            }
            new DataBaseSaver().Save(resultOfCompares, db);
        }
    }
}