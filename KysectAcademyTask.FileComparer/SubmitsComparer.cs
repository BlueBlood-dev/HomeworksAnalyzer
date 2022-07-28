using System.IO;

namespace KysectAcademyTask.FileComparer
{
    public class SubmitsComparer
    {
        public void CompareSubmits(Submit first, Submit second, DirectoryInfo firstSubmitInfo,
            DirectoryInfo secondSubmitInfo, IWriter writer, IComparator comparer, string outputPath)
        {
            foreach (FileInfo file1 in firstSubmitInfo.GetFiles())
            {
                foreach (FileInfo file2 in secondSubmitInfo.GetFiles())
                {
                    if (file1.Extension.Equals(file2.Extension))
                    {
                        writer.Write(outputPath, file1.FullName, file2.FullName,
                            comparer.Compare(file1.FullName, file2.FullName));
                    }
                }
            }
        }
    }
}