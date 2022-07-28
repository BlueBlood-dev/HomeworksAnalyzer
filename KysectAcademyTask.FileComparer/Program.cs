using KysectAcademyTask.DatabaseLayer.Entities;

namespace KysectAcademyTask.FileComparer
{
    
    internal static class Program
    {
        public static void Main(string[] args)
        {
            new DirectoryConfigReader().Read().CompareFiles();
        }
    }
}