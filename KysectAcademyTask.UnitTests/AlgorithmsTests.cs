using System;
using KysectAcademyTask.FileComparer;
using KysectAcademyTask.FileComparer.Selectors;
using Xunit;

namespace KysectAcademyTask.UnitTests
{
    public class AlgorithmsTests
    {
        [Fact]
        public void MultitudeAlgorithmTest()
        {
            IComparator comparator = new AppSettingsSelector().ChooseTheComparingAlgo("multitude algo");
            double actualResult = comparator.Compare("D:\\GitClone\\BlueBlood-dev\\KysectAcademyTask.UnitTests\\NewFile1.txt",
                "D:\\GitClone\\BlueBlood-dev\\KysectAcademyTask.UnitTests\\NewFile1.txt");
            Assert.Equal(100,actualResult);
        }
    }
}