namespace KysectAcademyTask.DatabaseLayer.Interfaces;

public interface IDataBaseInitializer
{
    DataBaseContext Build(IOptionsGetter optionsGetter);
}