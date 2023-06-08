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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarpoolEntry", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CarpoolEntry",
                columns: new[] { "Id", "Date", "Name" },
                values: new object[,]
                {
                { 1, "2023-03-28T00:00:00.000Z", "Jan" },
                { 2, "2023-04-01T00:00:00.000Z", "Gregor" },
                { 3, "2023-04-15T00:00:00.000Z", "Martin" },
                { 4, "2023-06-04T00:00:00.000Z", "Peter" }
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
