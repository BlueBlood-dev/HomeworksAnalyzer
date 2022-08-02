﻿using System;
using System.Collections.Generic;
using System.IO;
using KysectAcademyTask.FileComparer.Comparators;
using KysectAcademyTask.FileComparer.Interfaces;
using KysectAcademyTask.FileComparer.Models;
using KysectAcademyTask.FileComparer.Selectors;

namespace KysectAcademyTask.FileComparer.Controllers
{
    public class DirectoryController : IController
    {
        private readonly IComparator _comparator;
        private readonly IWriter _writer;
        private readonly ISubmitsComparerLogic _logic;
        private readonly string _inputPath;
        private readonly string _outputPath;
        private readonly List<string> _extensionWhiteList;
        private readonly List<string> _directoryBlackList;
        private readonly List<string> _authorWhiteList;
        private readonly List<string> _authorBlackList;

        public DirectoryController(IComparator comparator, ISubmitsComparerLogic logic, string inputPath,
            string outputPath, IWriter writer,
            List<string> extensionWhiteList, List<string> directoryBlackList, List<string> authorWhiteList,
            List<string> authorBlackList)
        {
            ArgumentNullException.ThrowIfNull(inputPath);
            ArgumentNullException.ThrowIfNull(outputPath);
            ArgumentNullException.ThrowIfNull(extensionWhiteList);
            ArgumentNullException.ThrowIfNull(directoryBlackList);
            ArgumentNullException.ThrowIfNull(authorWhiteList);
            ArgumentNullException.ThrowIfNull(authorBlackList);

            _comparator = comparator;
            _writer = writer;
            _logic = logic;
            _inputPath = inputPath;
            _outputPath = outputPath;
            _extensionWhiteList = extensionWhiteList;
            _directoryBlackList = directoryBlackList;
            _authorWhiteList = authorWhiteList;
            _authorBlackList = authorBlackList;
        }

        private string GetSubmitPath(Submit submit) 
            => Path.Combine(_inputPath, submit.GroupName, submit.StudentName, submit.HomeworkName, submit.SubmitName);

        public void CompareFiles()
        {
            List<Submit> submits = new DirectoryResearcher().Research(_inputPath, _directoryBlackList) ??
                                   throw new ArgumentNullException($"no submits in provided directory");
            IFilter filter = new WhiteAndBlackListFilter();
            filter.GetSubmitsWithoutIgnoredStudents(submits, _authorBlackList);
            List<Submit> whiteSubmits = filter.GetWhiteSubmits(submits, _authorWhiteList);
            SubmitsComparer comparer = new();

            int amountOfCmp = submits.Count * whiteSubmits.Count;
            int counter = 1;
            
            foreach (Submit whSubmit in whiteSubmits)
            {
                foreach (Submit submit in submits)
                {
                    if (whSubmit.HomeworkName.Equals(submit.HomeworkName) &&
                        !whSubmit.StudentName.Equals(submit.StudentName))
                    {
                        comparer.CompareSubmits(whSubmit, submit, new(GetSubmitPath(whSubmit)),
                            new DirectoryInfo(GetSubmitPath(submit)), _writer, _comparator, _outputPath);
                    }
                    Console.WriteLine($"{counter++}\\{amountOfCmp}");
                }
            }
        }
    }
}