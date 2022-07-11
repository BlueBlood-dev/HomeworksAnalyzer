namespace KysectAcademyTask.FileComparer
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
             FileController fileController = new ConfigReader().Read();
             fileController.CompareFiles();
        }
    }
}