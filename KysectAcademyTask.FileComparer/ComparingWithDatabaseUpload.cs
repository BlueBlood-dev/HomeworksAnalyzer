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
            if (!new DataBaseData().CheckIfInited())
            {
                dataBaseInitializer.Initialize(submits);
            }

            foreach (Submit whiteSubmit in whiteSubmits)
            {
                foreach (Submit submit in submits)
                {
                    int findStudentId = dataBaseInitializer.FindStudentId(whiteSubmit.StudentName, db);
                    int secondStudentId = dataBaseInitializer.FindStudentId(whiteSubmit.StudentName, db);
                    int firstSubmissionId = 0; // find by student id 
                    int secondSubmissionId = 0;// find by student id 
                    if (!new UniqueValueController().CheckIfResultExists(findStudentId, secondStudentId))
                    {
                        double result = new SubmitsComparer().CompareSubmits(whiteSubmit, submit,
                            new DirectoryInfo(new DirectorySubmitPathGetter().GetSubmitPath(whiteSubmit, inputPath)),
                            new DirectoryInfo(new DirectorySubmitPathGetter().GetSubmitPath(submit, inputPath)), writer,
                            comparator,
                            outputPath);
                        resultOfCompares.Add(new ResultOfCompare(firstSubmissionId,secondSubmissionId,result));
                    }
                }
            }
            new DataBaseSaver().Save(resultOfCompares,db);
        }
    }
}