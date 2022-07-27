using System;
using System.Collections.Generic;
using System.IO;

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
                    return new MultitudeComparator();
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
                    return new ConsoleWriter();
                case "txt":
                    return new FileWriter();
            }

            throw new InvalidOperationException();
        }
        

        private string GetSubmitPath(Submit submit)
        {
            return InputPath + "\\" + submit.GroupName + "\\" + submit.StudentName + "\\" + submit.HomeworkName + "\\" +
                   submit.SubmitName;
        }

        
        private void CompareSubmits(Submit first, Submit second, IWriter writer, IComparator comparator)
        {
            DirectoryInfo firstSubmitInfo = new(GetSubmitPath(first));
            DirectoryInfo secondSubmitInfo = new(GetSubmitPath(second));
            foreach (FileInfo file1 in firstSubmitInfo.GetFiles())
            {
                foreach (FileInfo file2 in secondSubmitInfo.GetFiles())
                {
                    if (file1.Extension.Equals(file2.Extension))
                    {
                        writer.Write(OutputPath, file1.FullName, file2.FullName,
                            comparator.Compare(file1.FullName, file2.FullName));
                    }
                }
            }
        }


        public void CompareFiles()
        {
            List<Submit> submits = new DirectoryResearcher().Research(InputPath, DirectoryBlackList) ??
                                   throw new ArgumentNullException($"no submits in provided directory");
            IWriter writer = ChooseTheOutputType();
            IComparator comparator = ChooseTheComparingAlgo();
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
                        CompareSubmits(whsubmit, submit, writer, comparator);
                    }

                    Console.WriteLine($"{counter++}\\{amountOfCmp}");
                }
            }
        }
    }
}