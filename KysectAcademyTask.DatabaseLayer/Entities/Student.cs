namespace KysectAcademyTask.DatabaseLayer.Entities
{
    public class Student
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string GroupName { get; set; }
        

        public Student(string name, string groupName)
        {
            Name = name;
            GroupName = groupName;
        }
    }
}
