using System.Collections.Generic;
using KysectAcademyTask.FileComparer;
using KysectAcademyTask.FileComparer.Models;
using Xunit;

namespace KysectAcademyTask.UnitTests
{
    public class StudentListTests
    {
        [Fact]
        public void BlackListTest()
        {
            List<string> blackList = new List<string> {"Jordan Bellford", "Kurt Cobain", "Ozzy Osbourne"};
            List<Submit> submits = new List<Submit>
            {
                new Submit("M3105", "Jordan Bellford", "7A Maths", "11111111"),
                new Submit("M3105", "Denis Khashchuk", "Pacifism and honor", "11111")
            };
            IFilter filter = new WhiteAndBlackListFilter();
            filter.GetSubmitsWithoutIgnoredStudents(submits, blackList);
            
            Assert.DoesNotContain(new Submit("M3105", "Jordan Bellford", "7A Maths", "11111111"), submits);
        }

        [Fact]
        public void WhiteListTest()
        {
            List<Submit> submits = new List<Submit>
            {
                new Submit("M3105", "Jordan Bellford", "7A Maths", "11111111"),
                new Submit("M3105", "Denis Khashchuk", "Pacifism and honor", "11111")
            };

            IFilter filter = new WhiteAndBlackListFilter();
            List<Submit> whiteSubmits = filter.GetWhiteSubmits(submits, new List<string> {"Denis Khashchuk"});
            Assert.DoesNotContain(new Submit("M3105", "Jordan Bellford", "7A Maths", "11111111"), whiteSubmits);
        }
    }
}