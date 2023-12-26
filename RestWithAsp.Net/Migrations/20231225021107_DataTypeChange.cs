using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestWithAsp.Net.Migrations
{
    /// <inheritdoc />
    public partial class DataTypeChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LaunchDate = table.Column<DateTime>(name: "Launch Date", type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(20,2)", precision: 20, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(name: "First Name", type: "nvarchar(80)", maxLength: 80, nullable: false),
                    LastName = table.Column<string>(name: "Last Name", type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Launch Date", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Michael C. Feathers", new DateTime(2017, 11, 29, 13, 50, 5, 878, DateTimeKind.Unspecified), 49.00m, "Working effectively with legacy code" },
                    { 2, "Ralph Johnson, Erich Gamma, John Vlissides e Richard Helm", new DateTime(2017, 11, 29, 15, 15, 13, 636, DateTimeKind.Unspecified), 77.00m, "Design Patterns" },
                    { 3, "Robert C. Martin", new DateTime(2009, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 67.00m, "Clean Code" },
                    { 4, "Crockford", new DateTime(2017, 11, 7, 15, 9, 1, 674, DateTimeKind.Unspecified), 67.00m, "JavaScript" },
                    { 5, "Steve McConnell", new DateTime(2017, 11, 7, 15, 9, 1, 674, DateTimeKind.Unspecified), 58.00m, "Refactoring" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Address", "First Name", "Gender", "Last Name" },
                values: new object[,]
                {
                    { 1, "São Paulo - Brasil", "Ayrton", "Male", "Senna" },
                    { 2, "Anchiano - Italy", "Leonardo", "Male", "da Vinci" },
                    { 3, "Porbandar - India", "Mahatma", "Male", "Gandhi" },
                    { 4, "Kentuky - USA", "Mohamed", "Male", "Ali" },
                    { 5, "Mvezo - South Africa", "Nelson", "Male", "Mandela" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
