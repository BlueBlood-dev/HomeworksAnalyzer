using Microsoft.EntityFrameworkCore;

namespace KysectAcademyTask.DatabaseLayer
{
    public class SimpleDbContextOptionsGetter : IOptionsGetter
    {
        public DbContextOptions<DataBaseContext> GetProvidedOptions()
        {
            return new DbContextOptionsBuilder<DataBaseContext>()
                .UseSqlServer(new AppSettingsConnectionGetter().GetConnectionString()).Options;
        }
    }
}