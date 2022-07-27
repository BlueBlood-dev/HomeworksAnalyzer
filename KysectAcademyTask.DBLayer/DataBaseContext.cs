using Microsoft.EntityFrameworkCore;

namespace KysectAcademyTask.DBLayer
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Student> Students { get; private init; } = null!;
        public DbSet<Submission> Submits { get; private init; } = null!;

        DataBaseContext()
        {
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=FileComparingDB;Trusted_Connection=True;");
        }
        
    }
}


