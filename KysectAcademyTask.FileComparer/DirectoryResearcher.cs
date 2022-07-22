﻿using System;
using System.Collections.Generic;
using System.IO;

namespace KysectAcademyTask.FileComparer
{
    public class DirectoryResearcher : IResearcher
    {
        private bool CheckIfDirectoryNotIgnored(List<string> directoryBlackList, string studentName, string groupName,
            string homeworkName, string submitName)
        {
            return !directoryBlackList.Contains(studentName) && !directoryBlackList.Contains(groupName) &&
                   !directoryBlackList.Contains(homeworkName) && !directoryBlackList.Contains(submitName);
        }

        public List<Submit> Research(string inputPath, List<string> directoryBlackList)
        {
            List<Submit> list = new List<Submit>();
            DirectoryInfo groups = new DirectoryInfo(inputPath);

            foreach (var group in groups.GetDirectories())
            {
                foreach (var students in group.GetDirectories())
                {
                    foreach (var homeworks in students.GetDirectories())
                    {
                        foreach (var submits in homeworks.GetDirectories())
                        {
                            if (CheckIfDirectoryNotIgnored(directoryBlackList, students.Name, group.Name,
                                homeworks.Name, submits.Name))
                                list.Add(new Submit(group.Name, students.Name, homeworks.Name, submits.Name));
                        }
                    }
                }
            }

            return list;
        }
    }
}