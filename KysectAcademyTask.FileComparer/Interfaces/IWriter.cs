namespace KysectAcademyTask.FileComparer.Interfaces;

public interface IWriter
{
    void Write(string output, string sourceFile, string targetFile, double compareResult);
}