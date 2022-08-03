using System.ComponentModel.DataAnnotations.Schema;

namespace KysectAcademyTask.DatabaseLayer.Entities
{
    public class Submission
    {
        public int Id { get; set; }
        public string HomeworkName { get; set;}
        [ForeignKey("Student")] public int StudentId { get; set; }
        
    }
}