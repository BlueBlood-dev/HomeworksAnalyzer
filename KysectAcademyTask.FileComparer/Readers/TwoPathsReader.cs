using KysectAcademyTask.FileComparer.Interfaces;
using KysectAcademyTask.FileComparer.Models;
using Microsoft.Extensions.Configuration;

namespace KysectAcademyTask.FileComparer.Readers;

public class TwoPathsReader : IReader
{
    public IConfigurationData Read()
    {
        IConfigurationRoot config = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json").Build();
        IConfigurationSection section = config.GetSection("FileController");
        string input = section.GetValue<string>("InputPath") ?? string.Empty;
        string output = section.GetValue<string>("OutputPath") ?? string.Empty;
        return new FilesConfigurationData(input, output);
    }
}