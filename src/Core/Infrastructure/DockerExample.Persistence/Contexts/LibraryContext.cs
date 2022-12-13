using AutoMapper.Execution;
using DockerExample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace DockerExample.Persistence.Contexts
{
  public class LibraryContext : DbContext
  {
    public LibraryContext()
    {
    }
    public LibraryContext(DbContextOptions<LibraryContext> options)
    : base(options)
    { }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //  var configuration = new ConfigurationBuilder()
    //      .SetBasePath(Directory.GetCurrentDirectory())
    //      .AddJsonFile("appsettings.json")
    //      .Build();

    //  var connStr = configuration.GetConnectionString("LibraryConnectionString");
    //  connStr = connStr.Replace("{AppDir}", AppDomain.CurrentDomain.BaseDirectory);
    //  optionsBuilder.UseSqlite(connStr);
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Book> Books { get; set; }
  }
}
