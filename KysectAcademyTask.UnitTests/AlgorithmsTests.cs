using KysectAcademyTask.FileComparer.Interfaces;
using KysectAcademyTask.FileComparer.Selectors;
using Xunit;

namespace KysectAcademyTask.UnitTests;

public class AlgorithmsTests
{
    [Fact]
    public void MultitudeAlgorithmTest()
    {
        IComparator comparator = new AppSettingsSelector().ChooseTheComparingAlgo("multitude algo");
        double actualResult = comparator.Compare("NewFile1.txt",
            "NewFile1.txt");
        Assert.Equal(100,actualResult);
    }
}