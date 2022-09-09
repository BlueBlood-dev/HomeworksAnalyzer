using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace KysectAcademyTask.DatabaseLayer;

public class SqLiteOptionsGetter : IOptionsGetter
{
    public DbContextOptions<DataBaseContext> GetProvidedOptions()
    {
        return new DbContextOptionsBuilder<DataBaseContext>().UseSqlite(new AppSettingsSqlLiteConnectionGetter().GetConnectionString()).Options;
    }
}