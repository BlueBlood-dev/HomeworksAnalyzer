using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace KysectAcademyTask.FileComparer
{
    public class DirectoryConfigReader : IReader
    {
        public IController Read()
        {
            IConfigurationRoot? config = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json").Build();

            IConfigurationSection
                configurationSection =
                    config.GetSection("DirectoryController"); //main sections which includes subsections
            string compAlgo = configurationSection.GetValue<string>("ComparationAlgotihms") ??
                                    throw new ArgumentNullException();
            string inputDirectory = configurationSection.GetValue<string>("InputDirectoryPath") ??
                                    throw new ArgumentNullException();

            IConfiguration reportSection = configurationSection.GetSection("Report");
            string path = reportSection.GetValue<string>("Path") ?? throw new ArgumentNullException();
            string type = reportSection.GetValue<string>("Type") ?? throw new ArgumentNullException();

            IConfiguration fileFiltersSection = configurationSection.GetSection("FileFilters");
            List<string> extensionsWhiteList = fileFiltersSection.GetValue<List<string>>("ExtensionsWhiteList") ??
                                               throw new ArgumentNullException();
            List<string> directoryBlackList = fileFiltersSection.GetValue<List<string>>("DirectoryBlackList") ??
                                              throw new ArgumentNullException();

            IConfiguration authorFiltersSection = configurationSection.GetSection("AuthorFilters");
            List<string> whiteList = authorFiltersSection.GetValue<List<string>>("WhiteList") ??
                                     throw new ArgumentNullException();

            List<string> blackList = authorFiltersSection.GetValue<List<string>>("BlackList") ??
                                     throw new ArgumentNullException();


            return new DirectoryController(compAlgo, inputDirectory, path, type, extensionsWhiteList,
                directoryBlackList, whiteList, blackList);
        }
    }
}