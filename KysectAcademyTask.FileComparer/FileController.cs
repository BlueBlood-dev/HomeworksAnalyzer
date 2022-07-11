using System;
using System.IO;

namespace KysectAcademyTask.FileComparer
{
    public class FileController
    {
        private string InputPath { get; }
        private string OutputPath { get; }

        public FileController(string inputPath, string outputPath)
        {
            ArgumentNullException.ThrowIfNull(inputPath);
            ArgumentNullException.ThrowIfNull(outputPath);
            
            if (!File.Exists(outputPath))
                throw new ArgumentException("There is no such file in output folder");
           
            string[] files = Directory.GetFiles(inputPath);
            if (files.Length < 2)
                throw new ArgumentException("There are less than two files in input directory");
            InputPath = inputPath;
            OutputPath = outputPath;
        }

        public void CompareFiles()
        {
            string[] files = Directory.GetFiles(InputPath);
            Comparator cmp = new Comparator();
            FileWriter fileWriter = new FileWriter();
            for (int i = 0; i < files.Length; i++)
            for (int j = i + 1; j < files.Length; j++)
                fileWriter.Write(OutputPath, files[i], files[j], cmp.Compare(files[i], files[j]));
        }
    }
}