using KysectAcademyTask.FileComparer.Interfaces;

namespace KysectAcademyTask.FileComparer.Comparators;

public class MultitudeComparator : IComparator
{
    public double Compare(string sourceFile, string targetFile)
    {
        string[] linesInSource = File.ReadAllLines(sourceFile);
        IEnumerable<string> difference = linesInSource.Except(File.ReadAllLines(targetFile));
        return (double) (linesInSource.Count() - difference.Count()) / linesInSource.Length * 100;
    }
}