using System;
using System.Collections.Generic;

namespace KysectAcademyTask.FileComparer
{
    public class DirectoryController : IController
    {
        private List<string> ComparingAlgo { get;  }
        private string InputPath { get; }
        private string OutputPath { get;  }
        private string TypeOfOutput { get; }
        private List<string> ExtensionWhiteList { get; }
        private List<string> DirectoryBlackList { get; }
        private List<string> AuthorWhiteList { get;  }
        private List<string> AuthorBlackList { get;  }

        public DirectoryController(List<string> comparingAlgo, string inputPath, string outputPath, string typeOfOutput, List<string> extensionWhiteList, List<string> directoryBlackList, List<string> authorWhiteList, List<string> authorBlackList)
        {
            
            ArgumentNullException.ThrowIfNull(comparingAlgo);
            ArgumentNullException.ThrowIfNull(inputPath);
            ArgumentNullException.ThrowIfNull(outputPath);
            ArgumentNullException.ThrowIfNull(typeOfOutput);
            ArgumentNullException.ThrowIfNull(extensionWhiteList);
            ArgumentNullException.ThrowIfNull(directoryBlackList);
            ArgumentNullException.ThrowIfNull(authorWhiteList);
            ArgumentNullException.ThrowIfNull(authorBlackList);
            
            ComparingAlgo = comparingAlgo;
            InputPath = inputPath;
            OutputPath = outputPath;
            TypeOfOutput = typeOfOutput;
            ExtensionWhiteList = extensionWhiteList;
            DirectoryBlackList = directoryBlackList;
            AuthorWhiteList = authorWhiteList;
            AuthorBlackList = authorBlackList;
        }
        
        public void CompareFiles()
        {
            
        }
    }
}