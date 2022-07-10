using System;
using System.IO;
using GroupDocs.Comparison;
namespace KysectAcademyTask.FileComparer
{
    public class FileController
    {
        public  string? InputPath { get; set; }
        public  string? OutputPath { get; set; }
        
        public FileController(){}
        
        public FileController(string inputPath, string outputPath)
         {
             ArgumentNullException.ThrowIfNull(inputPath);
             ArgumentNullException.ThrowIfNull(outputPath);
             string[] files = Directory.GetFiles(InputPath ?? string.Empty);
             if (files.Length < 2)
                 throw new ArgumentException("There are less than two files in input directory");
             InputPath = inputPath;
             OutputPath = outputPath;
         }
         public void CompareFiles()//change algo to damerau-levenshtein distance
        {
            string[] files = Directory.GetFiles(InputPath ?? string.Empty);
            
            for (int i = 0; i < files.Length; i++)
            {
                for (int j = i+1; j < files.Length; j++)
                {
                    Comparer comparer = new Comparer(File.OpenRead(files[i]));
                    comparer.Add(File.OpenRead(files[j]));
                    comparer.Compare(OutputPath);
                }
            }
        }
    }
}