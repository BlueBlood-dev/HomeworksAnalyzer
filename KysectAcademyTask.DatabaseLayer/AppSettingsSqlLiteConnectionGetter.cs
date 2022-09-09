using Microsoft.Extensions.Configuration;

namespace KysectAcademyTask.DatabaseLayer;

public class AppSettingsSqlLiteConnectionGetter : IConnectionGetter
{
    public string GetConnectionString()
    {
        IConfiguration configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("D:\\GitClone\\BlueBlood-dev\\KysectAcademyTask.FileComparer\\appsettings.json").Build();
            
        return configuration.GetSection("ConnectionStrings").GetValue<string>("SqlLiteServerConnection") ??
               throw new ArgumentNullException($"connection string in appsettings json is empty");
    }
}