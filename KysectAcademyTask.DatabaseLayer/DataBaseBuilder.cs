using Microsoft.EntityFrameworkCore;

namespace KysectAcademyTask.DatabaseLayer
{
    public class DataBaseBuilder : IDataBaseInitializer
    {
        public DataBaseContext Build()
        {
            return new DataBaseContext(new SimpleDbContextOptionsGetter().GetProvidedOptions());
        }
        
    }
}