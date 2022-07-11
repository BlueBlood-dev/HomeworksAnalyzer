namespace KysectAcademyTask.FileComparer
{
    public interface IComparator
    {
        double Compare(string sourceFile, string targetFile);
    }
}