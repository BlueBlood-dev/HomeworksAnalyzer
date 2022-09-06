﻿using Microsoft.Extensions.Configuration;

namespace KysectAcademyTask.DatabaseLayer;

public class AppSettingsConnectionGetter : IConnectionGetter
{
    public string GetConnectionString()
    {
        IConfiguration configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("D:\\GitClone\\BlueBlood-dev\\KysectAcademyTask.FileComparer\\appsettings.json").Build();
            
        return configuration.GetSection("ConnectionStrings").GetValue<string>("Connection") ??
               throw new ArgumentNullException($"connection string in appsettings json is empty");
    }
}