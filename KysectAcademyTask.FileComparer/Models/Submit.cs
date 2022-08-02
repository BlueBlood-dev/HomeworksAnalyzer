namespace KysectAcademyTask.FileComparer.Models
{
    public class Submit
    {
       public string GroupName { get;  }
       public string StudentName { get;  }
       public string HomeworkName { get; }
       public string SubmitName { get; }

       public Submit(string groupName, string studentName, string homeworkName, string submitName)
       {
           GroupName = groupName;
           StudentName = studentName;
           HomeworkName = homeworkName;
           SubmitName = submitName;
       }
    }
}