using Kusys.DAL.Extentions;
using Kusys.Domains.Domains;
using Microsoft.EntityFrameworkCore;

namespace Kusys.DAL.EfDbContext;

public class KusysDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    public DbSet<Course> Courses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=KusysDb;Persist Security Info=True;User ID=sa;Password=Admin*1234");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.InsertCourseData();

        modelBuilder.InertStudentsData();
    }
}