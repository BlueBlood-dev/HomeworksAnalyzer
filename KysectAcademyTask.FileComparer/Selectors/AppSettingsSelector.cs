using KysectAcademyTask.FileComparer.Comparators;
using KysectAcademyTask.FileComparer.Interfaces;
using KysectAcademyTask.FileComparer.Writers;

namespace KysectAcademyTask.FileComparer.Selectors;

public class AppSettingsSelector : ISelector
{
    public IComparator ChooseTheComparingAlgo(string comparingAlgo)
    {
        return comparingAlgo.ToLower() switch
        {
            "multitude algo" => new MultitudeComparator(),
            _ => throw new ArgumentException("there is no such algo")
        };
    }

    public IWriter ChooseTheOutputType(string typeOfOutput)
    {
        return typeOfOutput.ToLower() switch
        {
            "json" => new JsonWriter(),
            "console" => new ConsoleWriter(),
            "txt" => new FileWriter(),
            _ => throw new InvalidOperationException()
        };
    }

    public ISubmitsComparerLogic ChooseTheLogic(string userAnswer)
    {
        return userAnswer.ToLower() switch
        {
            "no" => new ComparingWithoutDatabaseUpload(),
            "yes" => new ComparingWithDatabaseUpload(),
            _ => throw new ArgumentException("invalid user choice")
        };
    }
}