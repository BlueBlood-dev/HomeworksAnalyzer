using KysectAcademyTask.FileComparer.Interfaces;

namespace KysectAcademyTask.FileComparer.Models;

public class FilesConfigurationData : IConfigurationData
{
    public string InputPath { get; }
    public string OutputPath { get; }

    public FilesConfigurationData(string inputPath, string outputPath)
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
}