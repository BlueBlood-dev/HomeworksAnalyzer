using KysectAcademyTask.FileComparer.Interfaces;

namespace KysectAcademyTask.FileComparer.Writers;

public class FileWriter : IWriter
{
    public void Write(string output, string sourceFile, string targetFile, double compareResult)
    {
        File.AppendAllText(output,
            sourceFile + " and " + targetFile + "  similar by: " + compareResult.ToString() + "%\n");
    }
}