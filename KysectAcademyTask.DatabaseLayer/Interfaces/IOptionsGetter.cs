using Microsoft.EntityFrameworkCore;

namespace KysectAcademyTask.DatabaseLayer.Interfaces;

public interface IOptionsGetter
{
    DbContextOptions<DataBaseContext> GetProvidedOptions();
}