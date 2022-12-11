using DockerExample.Application.Services.Repositories;
using DockerExample.Persistence.Contexts;
using DockerExample.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DockerExample.Persistence
{
  public static class ServiceRegistration
  {
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddDbContext<LibraryContext>(options => options.UseSqlite(configuration.GetConnectionString("LibraryConnectionString")));

      services.AddScoped<IBookRepository, BookRepository>();

      return services;
    }
  }
}
