namespace KysectAcademyTask.FileComparer
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
             IController directoryController = new DirectoryConfigReader().Read();
             directoryController.CompareFiles();
        }
    }
}