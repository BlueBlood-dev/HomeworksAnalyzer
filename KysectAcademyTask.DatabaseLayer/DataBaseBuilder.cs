using KysectAcademyTask.DatabaseLayer.Interfaces;

namespace KysectAcademyTask.DatabaseLayer;

public class DataBaseBuilder : IDataBaseInitializer
{
    public DataBaseContext Build(IOptionsGetter optionsGetter)
    {
        return new DataBaseContext(optionsGetter.GetProvidedOptions());
    }
        
}