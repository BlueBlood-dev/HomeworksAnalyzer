using System;
using System.Linq;
using KysectAcademyTask.DatabaseLayer.Entities;

namespace KysectAcademyTask.DatabaseLayer
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            using DataBaseContext db = new DataBaseBuilder().Build();
            // var st = new Student("Thomas Shelby", "M3105");
            // db.Add(st);
            // db.SaveChanges();
            // var students = db.Student.ToList();
            // foreach (Student student in students)
            // {
            //     Console.WriteLine($"{student.Id}: Name {student.Name} from group {student.GroupName}");
            // }
        }
    }
}