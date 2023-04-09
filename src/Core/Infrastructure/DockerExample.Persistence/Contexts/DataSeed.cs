using DockerExample.Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DockerExample.Persistence.Contexts
{
    public static class DataSeed
    {
        public static async Task Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<LibraryContext>();

            await context.Database.EnsureCreatedAsync();
            await context.Database.MigrateAsync();

            if (!context.Books.Any())
            {
                await context.Books.AddRangeAsync(new List<Book>
                {
                    new Book
                    {
                        Id = Guid.NewGuid(),
                        Name = "Poor Dad Rich Dad",
                        Page = 336,
                        CreateDate = DateTime.Now
                    },
                    new Book
                    {
                        Id = Guid.NewGuid(),
                        Name = "Richest Man In Babylon",
                        Page = 100,
                        CreateDate = DateTime.Now
                    }
                });
            }
        }
    }
}
