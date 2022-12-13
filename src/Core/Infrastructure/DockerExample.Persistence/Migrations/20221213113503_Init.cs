using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DockerExample.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Page = table.Column<int>(type: "INTEGER", nullable: false),
                    createdate = table.Column<DateTime>(name: "create_date", type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "id", "create_date", "name", "Page" },
                values: new object[,]
                {
                    { new Guid("39b0a39e-4dc0-46c8-9191-19d2357b3345"), new DateTime(2022, 12, 13, 14, 35, 3, 455, DateTimeKind.Local).AddTicks(3680), "Fast And Slow Thinking", 0 },
                    { new Guid("bcd38015-5a8d-41d1-a1fe-a4ca7ce87a27"), new DateTime(2022, 12, 13, 14, 35, 3, 455, DateTimeKind.Local).AddTicks(3658), "Rich Dad Poor Dad", 100 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books");
        }
    }
}
