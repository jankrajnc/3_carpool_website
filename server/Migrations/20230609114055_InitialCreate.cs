using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarpoolEntry",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarpoolEntry", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "CarpoolEntry",
                columns: new[] { "ID", "Date", "Name" },
                values: new object[,]
                {
                { 1, DateTime.Parse("2023-03-28T00:00:00.000Z").ToUniversalTime(), "Jan" },
                { 2, DateTime.Parse("2023-04-01T00:00:00.000Z").ToUniversalTime(), "Gregor" },
                { 3, DateTime.Parse("2023-04-15T00:00:00.000Z").ToUniversalTime(), "Martin" },
                { 4, DateTime.Parse("2023-06-04T00:00:00.000Z").ToUniversalTime(), "Peter" }
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarpoolEntry");
        }
    }
}
