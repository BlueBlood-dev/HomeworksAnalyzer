using KysectAcademyTask.FileComparer.Models;

namespace KysectAcademyTask.FileComparer.Interfaces;

public interface ISubmitsComparerLogic
{
    void ComparingProcess(List<Submit> submits, List<Submit> whiteSubmits, IComparator comparator, IWriter writer,
        string outputPath, string inputPath);
}