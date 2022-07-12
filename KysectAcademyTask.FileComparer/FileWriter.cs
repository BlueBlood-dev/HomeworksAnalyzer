using System.IO;

namespace KysectAcademyTask.FileComparer
{
    public class FileWriter : IWriter
    {
        public void Write(string output, string sourceFile, string targetFile, double compareResult)
        {
            File.AppendAllText(output,
                sourceFile + " and " + targetFile + "  similar by: " + compareResult.ToString() + "%\n");
        }
    }
}