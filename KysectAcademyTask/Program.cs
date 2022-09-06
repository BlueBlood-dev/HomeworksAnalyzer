using KysectAcademyTask.DatabaseLayer;
using KysectAcademyTask.FileComparer.Controllers;
using KysectAcademyTask.FileComparer.Models;
using KysectAcademyTask.FileComparer.Readers;

namespace KysectAcademyTask;

internal static class Program
{
    public static void Main()
    {
        new DirectoryController(new DirectoryConfigReader().Read() as DirectoryConfigurationData ?? throw new
            InvalidOperationException(), new DataBaseBuilder().Build());
    }
}