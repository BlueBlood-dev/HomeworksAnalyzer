using System;
using System.Collections.Generic;
using System.IO;

namespace KysectAcademyTask.FileComparer
{
    public class DirectoryController : IController
    {
        private IComparator Comparator { get; }
        private IWriter Writer { get; }
        private string InputPath { get; } 
        private string OutputPath { get; }
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

            ISelector selector = new AlgoAndOutputSelector();
            Comparator = selector.ChooseTheComparingAlgo(comparingAlgo);
            Writer = selector.ChooseTheOutputType(typeOfOutput);
            InputPath = inputPath;
            OutputPath = outputPath;
            ExtensionWhiteList = extensionWhiteList;
            DirectoryBlackList = directoryBlackList;
            AuthorWhiteList = authorWhiteList;
            AuthorBlackList = authorBlackList;
        }

        private string GetSubmitPath(Submit submit)
        {
            return InputPath + "\\" + submit.GroupName + "\\" + submit.StudentName + "\\" + submit.HomeworkName + "\\" +
                   submit.SubmitName;
        }


        private void CompareSubmits(Submit first, Submit second)
        {
            DirectoryInfo firstSubmitInfo = new(GetSubmitPath(first));
            DirectoryInfo secondSubmitInfo = new(GetSubmitPath(second));
            foreach (FileInfo file1 in firstSubmitInfo.GetFiles())
            {
                foreach (FileInfo file2 in secondSubmitInfo.GetFiles())
                {
                    if (file1.Extension.Equals(file2.Extension))
                    {
                        Writer.Write(OutputPath, file1.FullName, file2.FullName,
                            Comparator.Compare(file1.FullName, file2.FullName));
                    }
                }
            }
        }


        public void CompareFiles()
        {
            List<Submit> submits = new DirectoryResearcher().Research(InputPath, DirectoryBlackList) ??
                                   throw new ArgumentNullException($"no submits in provided directory");
            IFilter filter = new WhiteAndBlackListFilter();
            filter.GetSubmitsWithoutIgnoredStudents(submits, AuthorBlackList);
            List<Submit> whiteSubmits = filter.GetWhiteSubmits(submits, AuthorWhiteList);

            int amountOfCmp = submits.Count * whiteSubmits.Count;
            int counter = 1;
            foreach (Submit whsubmit in whiteSubmits)
            {
                foreach (Submit submit in submits)
                {
                    if (whsubmit.HomeworkName.Equals(submit.HomeworkName) &&
                        !whsubmit.StudentName.Equals(submit.StudentName))
                    {
                        CompareSubmits(whsubmit, submit);
                    }

                    Console.WriteLine($"{counter++}\\{amountOfCmp}");
                }
            }
        }
    }
}