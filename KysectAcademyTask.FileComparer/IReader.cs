using System.Xml.Linq;

namespace KysectAcademyTask.FileComparer
{
    public interface IReader
    {
        IController Read();
    }
}