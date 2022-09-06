using KysectAcademyTask.FileComparer.Readers;

namespace KysectAcademyTask.FileComparer;

internal static class Program
{
    public static void Main() 
    {
        new DirectoryConfigReader().Read().CompareFiles();
    }
}