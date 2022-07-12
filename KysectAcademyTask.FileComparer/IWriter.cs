namespace KysectAcademyTask.FileComparer
{
    public interface IWriter
    {
        void Write(string output, string sourceFile, string targetFile, double compareResult);
    }
}