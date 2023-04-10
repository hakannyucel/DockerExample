using DockerExample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DockerExample.Persistence.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("books");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
              .HasColumnName("id")
              .IsRequired();

            builder.Property(x => x.Name)
              .HasColumnName("name")
              .HasMaxLength(100)
              .IsRequired();

            builder.Property(x => x.Page)
                .HasColumnName("page")
                .IsRequired();

            builder.Property(x => x.CreateDate)
              .HasColumnName("create_date")
              .IsRequired();

            List<Book> books = new List<Book>
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
              };

            builder.HasData(books);
        }
    }
}
