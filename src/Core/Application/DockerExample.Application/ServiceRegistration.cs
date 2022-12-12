using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DockerExample.Application
{
  public static class ServiceRegistration
  {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
      var assembly = Assembly.GetExecutingAssembly();

      services.AddAutoMapper(assembly);
      services.AddMediatR(assembly);
      services.AddValidatorsFromAssembly(assembly);

      return services;
    }
  }
}
