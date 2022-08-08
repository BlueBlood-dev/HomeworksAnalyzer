using System;
using System.Linq;
using KysectAcademyTask.DatabaseLayer.Entities;

namespace KysectAcademyTask.DatabaseLayer
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            DataBaseContext db = new DataBaseBuilder().Build();
        }
    }
}