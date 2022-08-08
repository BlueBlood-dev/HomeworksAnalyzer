using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
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
            // foreach (Student student in db.Student.ToList().Where(student => student.Name == studentName))
            // {
            //     return student.Id;
            // }
           // Console.WriteLine(db.Student.ToList().Count);
            foreach (Student student in db.Student.ToList())
            {
                if (student.Name == studentName)
                    return student.Id;
            }

            throw new Exception("student wasn't found");
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

            
            
            foreach (Submit submit in submits)
            {
                Submission submission = new Submission(submit.SubmitName, FindStudentId(submit.StudentName,db),
                    submit.HomeworkName);
                db.Add(submission);
            }

            db.SaveChanges();
        }
    }
}