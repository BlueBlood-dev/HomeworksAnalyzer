using Microsoft.EntityFrameworkCore;

namespace KysectAcademyTask.DatabaseLayer;

public class SqlServerOptionsGetter : IOptionsGetter
{
    public DbContextOptions<DataBaseContext> GetProvidedOptions()
    {
        return new DbContextOptionsBuilder<DataBaseContext>()
            .UseSqlServer(new AppSettingsSqlServerConnectionGetter().GetConnectionString()).Options;
        
    }
}