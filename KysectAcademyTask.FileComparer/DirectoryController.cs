using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace KysectAcademyTask.FileComparer
{
    public class DirectoryController : IController
    {
        private string ComparingAlgo { get; }
        private string InputPath { get; }
        private string OutputPath { get; }
        private string TypeOfOutput { get; }
        private List<string> ExtensionWhiteList { get; }
        private List<string> DirectoryBlackList { get; }
        private List<string> AuthorWhiteList { get; }
        private List<string> AuthorBlackList { get; }

        public DirectoryController(string comparingAlgo, string inputPath, string outputPath, string typeOfOutput,
            List<string> extensionWhiteList, List<string> directoryBlackList, List<string> authorWhiteList,
            List<string> authorBlackList)
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

        private IComparator ChooseTheComparingAlgo()
        {
            switch (ComparingAlgo.ToLower())
            {
                case "multitude algo":
                    return new Comparator();
                default:
                    throw new ArgumentException("there is no such algo");
            }
        }

        private IWriter ChooseTheOutputType()
        {
            switch (TypeOfOutput.ToLower())
            {
                case "json":
                    return new JsonWriter();
                case "console":
                    throw new NotImplementedException();
                case "file":
                    throw new NotImplementedException();
            }

            throw new InvalidOperationException();
        }


        void RemoveBlackListAuthors(List<Submit> submits)
        {
            List<int> toDeleteElements = new List<int>();
            for (int i = 0; i < submits.Count; i++)
            {
                if (AuthorBlackList.Contains(submits[i].StudentName))
                {
                    toDeleteElements.Add(i);
                }
            }

            foreach (int index in toDeleteElements)
            {
                submits.RemoveAt(index);
            }
        }


        public void CompareFiles()
        {
            List<Submit> submits = new DirectoryResearcher().Research(InputPath, DirectoryBlackList) ??
                                   throw new ArgumentNullException($"no submits in provided directory");
            RemoveBlackListAuthors(submits);
            
        }
    }
}