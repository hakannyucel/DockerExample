using DockerExample.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DockerExample.Persistence.Contexts
{
    public static class DataSeed
    {
        public static void Seed()
        {
            using (var context = new LibraryContext())
            {
                context.Database.Migrate();

                if (!context.Books.Any())
                {
                    context.AddRange(new List<Book>
                    {
                        new Book
                        {
                          Name = "Rich Dad Poor Dad",
                          Page = 100
                        },
                        new Book
                        {
                          Name = "Fast And Slow Thinking"
                        }
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
