// See https://aka.ms/new-console-template for more information

using System;
using Microsoft.Extensions.Configuration;

namespace KysectAcademyTask.FileComparer
{
    class Program
    {
        public static void Main(string[] args)
        {
            IConfigurationRoot? config = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json").Build(); 
            FileController? pathKeeperConfig = config.GetSection(nameof(FileController)).Get<FileController>();
            pathKeeperConfig?.CompareFiles();
        }
    }
}