using KysectAcademyTask.FileComparer.Interfaces;

namespace KysectAcademyTask.FileComparer.Writers;

public class ConsoleWriter : IWriter
{
    public void Write(string output, string sourceFile, string targetFile, double compareResult)
    {
        Console.WriteLine($"{sourceFile} looks like {targetFile} by {compareResult}");
    }
}