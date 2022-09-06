using KysectAcademyTask.DatabaseLayer;
using KysectAcademyTask.FileComparer.FileSystemResearchers;
using KysectAcademyTask.FileComparer.Filters;
using KysectAcademyTask.FileComparer.Interfaces;
using KysectAcademyTask.FileComparer.Models;


namespace KysectAcademyTask.FileComparer.Controllers;

public class DirectoryController : IController
{
    private readonly DirectoryConfigurationData _configurationData;

    private readonly DataBaseContext _dataBaseContext;

    public DirectoryController(DirectoryConfigurationData configurationData, DataBaseContext dataBaseContext)
    {
        _configurationData = configurationData;
        _dataBaseContext = dataBaseContext;
    }


    public void CompareFiles()
    {
        List<Submit> submits =
            new DirectoryResearcher().Research(_configurationData.InputPath,
                _configurationData.GetDirectoryBlackList()) ??
            throw new ArgumentNullException($"no submits in provided directory");
        
        IFilter filter = new WhiteAndBlackListFilter();
        filter.GetSubmitsWithoutIgnoredStudents(submits, _configurationData.GetAuthorBlackList());
        List<Submit> whiteSubmits = filter.GetWhiteSubmits(submits, _configurationData.GetAuthorWhiteList());
        
        _configurationData.Logic.ComparingProcess(submits, whiteSubmits, _configurationData.Comparator,
            _configurationData.Writer, _configurationData.OutputPath, _configurationData.InputPath,_dataBaseContext);
    }
}