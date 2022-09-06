using KysectAcademyTask.FileComparer.Interfaces;

namespace KysectAcademyTask.FileComparer.Models;

public class DirectoryConfigurationData : IConfigurationData
{
    private readonly List<string> _extensionWhiteList;
    private readonly List<string> _directoryBlackList;
    private readonly List<string> _authorWhiteList;
    private readonly List<string> _authorBlackList;
    public  IComparator Comparator { get; }
    public IWriter Writer { get; }
    public ISubmitsComparerLogic Logic { get; }
    public string InputPath { get; }
    public string OutputPath { get; }


    public DirectoryConfigurationData(IComparator comparator, ISubmitsComparerLogic logic, string inputPath,
        string outputPath, IWriter writer,
        List<string> extensionWhiteList, List<string> directoryBlackList, List<string> authorWhiteList,
        List<string> authorBlackList)
    {
        Comparator = comparator;
        Writer = writer;
        Logic = logic;
        InputPath = inputPath;
        OutputPath = outputPath;
        _extensionWhiteList = extensionWhiteList;
        _directoryBlackList = directoryBlackList;
        _authorWhiteList = authorWhiteList;
        _authorBlackList = authorBlackList;
    }

    public IReadOnlyCollection<string> GetExtensionWhiteList()
    {
        return _extensionWhiteList.AsReadOnly();
    }
    
    public IReadOnlyCollection<string> GetDirectoryBlackList()
    {
        return _directoryBlackList.AsReadOnly();
    }
    
    public IReadOnlyCollection<string> GetAuthorWhiteList()
    {
        return _authorWhiteList.AsReadOnly();
    }
    
    public IReadOnlyCollection<string> GetAuthorBlackList()
    {
        return _authorBlackList.AsReadOnly();
    }
}