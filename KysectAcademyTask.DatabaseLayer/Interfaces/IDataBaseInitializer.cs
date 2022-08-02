using System;
using Microsoft.EntityFrameworkCore;

namespace KysectAcademyTask.DatabaseLayer
{
    public interface IDataBaseInitializer
    {
        DataBaseContext Build();
    }
}