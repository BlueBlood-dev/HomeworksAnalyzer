using System.Collections.Generic;
using System.Linq;
using KysectAcademyTask.DatabaseLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace KysectAcademyTask.DatabaseLayer
{
    public class DataBaseData
    {
        public IReadOnlyCollection<Submission> Submissions { get; }
        public IReadOnlyCollection<Student> Students { get; }
        public IReadOnlyCollection<ResultOfCompare> ResultsOfCompares { get; }

        public DataBaseData()
        {
            using DataBaseContext db = new DataBaseBuilder().Build();
            Submissions = db.Submissions.Include("Student").ToList();
            Students = db.Student.Include("Submission").ToList();
            ResultsOfCompares = db.Results.Include("Submission").ToList();
        }

        public bool CheckIfInited()
        {
            return Submissions is not null && Students is not null;
        }

    }
    
}