using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KysectAcademyTask.FileComparer
{
    public class Comparator : IComparator
    {
        public double Compare(string sourceFile, string targetFile)
        {
            string[] linesInSource = File.ReadAllLines(sourceFile);
            IEnumerable<string>? difference = linesInSource.Except(File.ReadAllLines(targetFile));
            return (double) (linesInSource.Count() - difference.Count()) / linesInSource.Length * 100;
        }
    }
}