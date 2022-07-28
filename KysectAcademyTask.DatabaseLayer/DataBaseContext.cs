using KysectAcademyTask.DatabaseLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace KysectAcademyTask.DatabaseLayer
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Student> Student { get; private init; } = null!;
        public DbSet<Submission> Submissions { get; private init; } = null!;
        public DbSet<ResultOfCompare> Results { get; private init; } = null!;

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}