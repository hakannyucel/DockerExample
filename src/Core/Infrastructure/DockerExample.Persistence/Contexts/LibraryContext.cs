using DockerExample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DockerExample.Persistence.Contexts
{
  public class LibraryContext : DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Data Source=/library.db;Version=3;\r\n");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Book> Books { get; set; }
  }
}
