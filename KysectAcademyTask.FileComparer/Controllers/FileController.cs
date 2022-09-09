using KysectAcademyTask.FileComparer.Comparators;
using KysectAcademyTask.FileComparer.Interfaces;
using KysectAcademyTask.FileComparer.Models;
using KysectAcademyTask.FileComparer.Writers;

namespace KysectAcademyTask.FileComparer.Controllers;

public class FileController : IController
{

    private FilesConfigurationData _configurationData;


    public FileController(FilesConfigurationData configurationData)
    {
        _configurationData = configurationData;
    }

    public void CompareFiles()
    {
        string[] files = Directory.GetFiles(_configurationData.InputPath);
        var cmp = new MultitudeComparator();
        var fileWriter = new FileWriter();
        for (int i = 0; i < files.Length; i++)
        {
            for (int j = i + 1; j < files.Length; j++)
                fileWriter.Write(_configurationData.OutputPath, files[i], files[j], cmp.Compare(files[i], files[j]));
        }
    }
}