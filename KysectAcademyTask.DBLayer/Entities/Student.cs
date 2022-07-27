namespace KysectAcademyTask.DBLayer
{

    public class Student
    {
        public int Id { get; }
        public string Name { get;  }
        public string GroupName { get;  }
        
        

        public Student(string name, string groupName, int id)
        {
            Name = name;
            GroupName = groupName;
            Id = id;
        }
    }
}