// <auto-generated />
using System;
using DockerExample.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DockerExample.Persistence.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20221213113503_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("DockerExample.Domain.Entities.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("create_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<int>("Page")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("books", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("bcd38015-5a8d-41d1-a1fe-a4ca7ce87a27"),
                            CreateDate = new DateTime(2022, 12, 13, 14, 35, 3, 455, DateTimeKind.Local).AddTicks(3658),
                            Name = "Rich Dad Poor Dad",
                            Page = 100
                        },
                        new
                        {
                            Id = new Guid("39b0a39e-4dc0-46c8-9191-19d2357b3345"),
                            CreateDate = new DateTime(2022, 12, 13, 14, 35, 3, 455, DateTimeKind.Local).AddTicks(3680),
                            Name = "Fast And Slow Thinking",
                            Page = 0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
