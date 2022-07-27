namespace KysectAcademyTask.DataBaseLayer
{
    public class Student
    {
        public string GroupName { get;}
        public string Name { get; }

        public Student(string groupName, string name)
        {
            GroupName = groupName;
            Name = name;
        }
    }
}