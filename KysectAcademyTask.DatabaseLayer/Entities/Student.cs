using System.Collections;
using System.Collections.Generic;

namespace KysectAcademyTask.DatabaseLayer.Entities
{
    public class Student
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string GroupName { get; set; }
        
        public ICollection<Submission> Submissions { get; set; }
     
    }
}
