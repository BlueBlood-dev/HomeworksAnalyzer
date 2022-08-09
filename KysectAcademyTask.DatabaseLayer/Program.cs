namespace KysectAcademyTask.DatabaseLayer
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            DataBaseContext db = new DataBaseBuilder().Build();
        }
    }
}