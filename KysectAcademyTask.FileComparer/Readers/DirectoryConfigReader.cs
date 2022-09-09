using KysectAcademyTask.FileComparer.Interfaces;
using KysectAcademyTask.FileComparer.Models;
using KysectAcademyTask.FileComparer.Selectors;
using Microsoft.Extensions.Configuration;

namespace KysectAcademyTask.FileComparer.Readers;

public class DirectoryConfigReader : IReader
{
    private List<string> GetBlackList(IConfigurationSection configurationSection)
    {
        IEnumerable<IConfigurationSection> children = configurationSection.GetSection("BlackList").GetChildren();
        var list = new List<string>();
        foreach (IConfigurationSection variable in children)
        {
            if (variable.Value is not null)
            {
                list.Add(variable.Value);
            }
        }

        return list ?? throw new ArgumentNullException($"black list is empty");
    }


    private List<string> GetWhiteList(IConfigurationSection configurationSection)
    {
        IEnumerable<IConfigurationSection> children = configurationSection.GetSection("WhiteList").GetChildren();
        var list = new List<string>();
        foreach (IConfigurationSection variable in children)
        {
            if (variable.Value is not null)
            {
                list.Add(variable.Value);
            }
        }

        return list ?? throw new ArgumentNullException($"white list is empty");
    }

    private string GetInputPath(IConfigurationSection configurationSection)
    {
        return configurationSection.GetValue<string>("InputDirectoryPath") ??
               throw new ArgumentNullException($"input path is null");
    }

    private string GetAlgo(IConfigurationSection configurationSection)
    {
        return configurationSection.GetValue<string>("ComparationAlgotihms") ??
               throw new ArgumentNullException($"algo is null");
    }

    private string GetOutput(IConfigurationSection configurationSection)
    {
        return configurationSection.GetValue<string>("Path") ??
               throw new ArgumentNullException($"output path is null");
    }

    private string GetType(IConfigurationSection configurationSection)
    {
        return configurationSection.GetValue<string>("Type") ?? throw new ArgumentNullException($"Type is null");
    }

    private List<string> GetExtensionsWhiteList(IConfigurationSection configurationSection)
    {
        IEnumerable<IConfigurationSection> children =
            configurationSection.GetSection("ExtensionsWhiteList").GetChildren();
        var list = new List<string>();
        foreach (IConfigurationSection variable in children)
        {
            if (variable.Value is not null)
            {
                list.Add(variable.Value);
            }
        }

        return list ?? throw new ArgumentNullException($"extensions white  list is empty");
    }

    private List<string> GetDirectoryBlackList(IConfigurationSection configurationSection)
    {
        IEnumerable<IConfigurationSection> children =
            configurationSection.GetSection("DirectoryBlackList").GetChildren();
        List<string> list = new();
        IEnumerable<string> blackList = children
            .Where(section => section.Value is not null)
            .Select(section => section.Value!);
        list.AddRange(blackList);

        return list ?? throw new ArgumentNullException($"directory black list is empty");
    }

    private string GetDataBaseUploadChoice(IConfigurationSection configurationSection)
    {
        return configurationSection.GetValue<string>("Answer") ??
               throw new ArgumentNullException($"answer is null");
    }


    public IConfigurationData Read()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("D:\\GitClone\\BlueBlood-dev\\KysectAcademyTask.FileComparer\\appsettings.json").Build();
        IConfigurationSection section = config.GetSection("InputAndPath") ??
                                        throw new ArgumentException("there is no such section");

        string inputPath = GetInputPath(section);
        string algo = GetAlgo(section);

        section = config.GetSection("Report");

        string output = GetOutput(section);
        string typeOfOutput = GetType(section);

        ISelector selector = new AppSettingsSelector();
        IWriter writer = selector.ChooseTheOutputType(typeOfOutput);
        IComparator comparator = selector.ChooseTheComparingAlgo(algo);

        section = config.GetSection("AuthorFilters") ??
                  throw new ArgumentException("AuthorFilter doesn't exist");

        List<string> whiteList = GetWhiteList(section);
        List<string> blackList = GetBlackList(section);

        section = config.GetSection("FileFilters") ?? throw new ArgumentException("FileFilters");

        List<string> extensionsWhiteList = GetExtensionsWhiteList(section);
        List<string> directoryBlackList = GetDirectoryBlackList(section);

        section = config.GetSection("UploadDataBase") ??
                  throw new ArgumentException("UploadDataBase field doesn't exist");

        string logicChoice = GetDataBaseUploadChoice(section);
        ISubmitsComparerLogic logic = selector.ChooseTheLogic(logicChoice);

        return new DirectoryConfigurationData(comparator, logic, inputPath, output, writer, extensionsWhiteList,
            directoryBlackList, whiteList, blackList);
    }
}