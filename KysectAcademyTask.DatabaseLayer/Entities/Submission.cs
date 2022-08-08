using System.ComponentModel.DataAnnotations.Schema;

namespace KysectAcademyTask.DatabaseLayer.Entities
{
    public class Submission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string HomeWorkName { get; set; }
        
        [ForeignKey("Student")] public int StudentId { get; set; }

        public Submission(string name, int studentId, string homeWorkName)
        {
            HomeWorkName = homeWorkName;
            Name = name;
            StudentId = studentId;
        }
    }
}