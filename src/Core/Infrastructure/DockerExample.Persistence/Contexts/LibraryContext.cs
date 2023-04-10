using DockerExample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DockerExample.Persistence.Contexts
{
    public class LibraryContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var databaseServer = Environment.GetEnvironmentVariable("DATABASE_SERVER");
            var databaseName = Environment.GetEnvironmentVariable("DATABASE_NAME");
            var databaseUser = Environment.GetEnvironmentVariable("DATABASE_USER");
            var databasePass = Environment.GetEnvironmentVariable("DATABASE_PASS");
            var isLocalConn = Environment.GetEnvironmentVariable("IS_LOCAL") is not null ? Convert.ToBoolean(Environment.GetEnvironmentVariable("IS_LOCAL")) : true;

            var connString = isLocalConn
                ? $"Server={databaseServer};Database={databaseName};Trusted_Connection=True;"
                : $"Server={databaseServer};Database={databaseName};User Id={databaseUser};Password={databasePass};TrustServerCertificate=True;";

            optionsBuilder.UseSqlServer(connString);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Book> Books { get; set; }
    }
}
