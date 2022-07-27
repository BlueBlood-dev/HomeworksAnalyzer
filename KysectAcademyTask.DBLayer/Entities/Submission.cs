using System.ComponentModel.DataAnnotations.Schema;

namespace KysectAcademyTask.DBLayer
{
    public class Submission
    {
        public int Id { get; }
        [ForeignKey("Student")] public int StudentSubmissionId { get; }
        private string HomeworkName { get; }

        public Submission(int id, int studentSubmissionId, string homeworkName)
        {
            Id = id;
            StudentSubmissionId = studentSubmissionId;
            HomeworkName = homeworkName;
        }
    }
}