using Microsoft.EntityFrameworkCore;

namespace KysectAcademyTask.DatabaseLayer;

public interface IOptionsGetter
{
    DbContextOptions<DataBaseContext> GetProvidedOptions();
}