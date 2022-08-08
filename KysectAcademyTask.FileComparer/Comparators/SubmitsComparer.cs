using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using KysectAcademyTask.FileComparer.Models;

namespace KysectAcademyTask.FileComparer.Comparators
{
    public class SubmitsComparer
    {
        public double CompareSubmits(Submit first, Submit second, DirectoryInfo firstSubmitInfo,
            DirectoryInfo secondSubmitInfo, IWriter writer, IComparator comparer, string outputPath)
        {
            List<double> compareResults = new();
            Console.WriteLine("1");
            foreach (FileInfo file1 in firstSubmitInfo.GetFiles())
            {
                Console.WriteLine("2");
                foreach (FileInfo file2 in secondSubmitInfo.GetFiles())
                {
                    Console.WriteLine("3");
                    Console.WriteLine(file2.Name);
                    if (file1.Extension.Equals(file2.Extension))
                    {
                        double result = comparer.Compare(file1.FullName, file2.FullName);
                        compareResults.Add(result);
                        writer.Write(outputPath, file1.FullName, file2.FullName,
                            result);
                        Console.WriteLine("4");// extensions are bad
                    }
                }
            }
            Console.WriteLine("FINISHED");
            if (compareResults.Count == 0)
                return 0;
            return compareResults.Average();
        }
    }
}