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

        public DataBaseData(DataBaseContext db)
        {
            Submissions = db.Submissions.ToList();
            Students = db.Student.ToList();
            ResultsOfCompares = db.Results.ToList();
        }

        public bool CheckIfInitialized()
        {
            return Submissions is not null && Students is not null;
        }

    }
    
}