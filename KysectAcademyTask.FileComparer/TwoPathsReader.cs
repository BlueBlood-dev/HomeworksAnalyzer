using Microsoft.Extensions.Configuration;

namespace KysectAcademyTask.FileComparer
{
    public class ConfigReader
    {
        public FileController Read()
        {
            IConfigurationRoot config = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json").Build();
            IConfigurationSection section = config.GetSection("FileController");
            string input = section.GetValue<string>("InputPath") ?? string.Empty;
            string output = section.GetValue<string>("OutputPath") ?? string.Empty;
            return new FileController(input, output);
        }
    }
}