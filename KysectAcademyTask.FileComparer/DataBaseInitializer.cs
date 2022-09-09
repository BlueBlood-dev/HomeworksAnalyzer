using KysectAcademyTask.DatabaseLayer;
using KysectAcademyTask.DatabaseLayer.Entities;
using KysectAcademyTask.FileComparer.Models;

namespace KysectAcademyTask.FileComparer;

public class DataBaseInitializer
{
    public int FindStudentId(string studentName,DataBaseContext db)
    {
        foreach (Student student in db.Student.ToList().Where(student => student.Name == studentName))
        {
            return student.Id;
        }

        throw new Exception("student wasn't found");
    }

    public int FindSubmissionId(int studentId, DataBaseContext db)
    {
        foreach (Submission submission in db.Submissions.ToList().Where(submission => submission.StudentId == studentId))
        {
            return submission.Id;
        }

        throw new Exception("submission wasn't found");
    }


    public void Initialize(List<Submit> submits,DataBaseContext db)
    {
        List<string> names = new();
        foreach (Submit submit in submits)
        {
            if (!names.Contains(submit.StudentName))
            {
                var student = new Student(submit.StudentName, submit.GroupName);
                db.Add(student);
                names.Add(submit.StudentName);
            }
                
        }

        db.SaveChanges();

            
            
        foreach (Submission submission in submits.Select(submit => new Submission(submit.SubmitName, FindStudentId(submit.StudentName,db),
                     submit.HomeworkName)))
        {
            db.Add(submission);
        }

        db.SaveChanges();
    }
}