using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace KysectAcademyTask.FileComparer
{
    public class DirectoryConfigReader : IReader
    {

        private List<string> GetBlackList(IConfigurationSection configurationSection)
        {
           IEnumerable<IConfigurationSection> children = configurationSection.GetSection("BlackList").GetChildren();
           List<string> list = new List<string>();
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
            List<string> list = new List<string>();
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
            IEnumerable<IConfigurationSection> children = configurationSection.GetSection("ExtensionsWhiteList").GetChildren();
            List<string> list = new List<string>();
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
            IEnumerable<IConfigurationSection> children = configurationSection.GetSection("DirectoryBlackList").GetChildren();
            List<string> list = new List<string>();
            foreach (IConfigurationSection variable in children)
            {
                if (variable.Value is not null)
                {
                    list.Add(variable.Value);
                }
            }

            return list ?? throw new ArgumentNullException($"directory black list is empty");
        }


        public IController Read()
        {
            IConfigurationRoot config = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json").Build();
            IConfigurationSection section = config.GetSection("InputAndPath") ??
                                            throw new ArgumentException("there is no such section");
            
            string inputPath = GetInputPath(section);
            string algo = GetAlgo(section);

            section = config.GetSection("Report");
            
            string output = GetOutput(section);
            string typeOfOutput = GetType(section);
            
            section = config.GetSection("AuthorFilters") ??
                      throw new ArgumentException("AuthorFilter doesn't exist");
            
            List<string> whiteList = GetWhiteList(section);
            List<string> blackList = GetBlackList(section);

            section = config.GetSection("FileFilters") ?? throw new ArgumentException("FileFilters");

            List<string> extensionsWhiteList = GetExtensionsWhiteList(section);
            List<string> directoryBlackList = GetDirectoryBlackList(section);



            return new DirectoryController(algo, inputPath, output, typeOfOutput, extensionsWhiteList,
                directoryBlackList, whiteList, blackList);
        }
    }
}