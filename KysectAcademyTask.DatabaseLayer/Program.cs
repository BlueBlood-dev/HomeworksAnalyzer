using System;
using System.Linq;
using KysectAcademyTask.DatabaseLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace KysectAcademyTask.DatabaseLayer
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataBaseContext>();
            DbContextOptions<DataBaseContext> options = optionsBuilder
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;").Options;
            using (DataBaseContext db = new DataBaseContext(options))
            {
                Student st = new();
                st.Name = "Thomas Shelby";
                st.GroupName = "M3105";
                db.Add(st);
                db.SaveChanges();
                var students = db.Student.ToList();
                foreach (Student student in students)
                {
                    Console.WriteLine($"{student.Id}: Name {student.Name} from group {student.GroupName}");
                }
            }
        }
    }
}