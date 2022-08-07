using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using KysectAcademyTask.DatabaseLayer;
using KysectAcademyTask.DatabaseLayer.Entities;
using KysectAcademyTask.FileComparer.Models;

namespace KysectAcademyTask.FileComparer
{
    public class DataBaseInitializer
    {
        public int FindStudentId(string studentName,DataBaseContext db)
        {
            foreach (var student in db.Student.ToList().Where(student => student.Name == studentName))
            {
                return student.Id;
            }

            throw new Exception("Student's id wasn't found");
        }


        public void Initialize(IReadOnlyCollection<Submit> submits)
        {
            using DataBaseContext db = new DataBaseBuilder().Build();
            foreach (Submit submit in submits)
            {
                var student = new Student(submit.StudentName, submit.GroupName);
                db.Add(student);
            }

            foreach (Submit submit in submits)
            {
                Submission submission = new Submission(submit.GroupName, FindStudentId(submit.StudentName,db),
                    submit.HomeworkName);
                db.Add(submission);
            }

            db.SaveChanges();
        }
    }
}