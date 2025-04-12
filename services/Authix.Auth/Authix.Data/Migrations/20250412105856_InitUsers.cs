using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Authix.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "$2a$11$Lro27MtCVaQ4qKU72YZ7CO0gGDUoL4fpHWh46t02r1HTWrXNLWaJO", 2, "Squee" },
                    { 2, "$2a$11$qK1dnONJri1jf8sEt4jmF.hjEcwFb15N5Kl9bOYTVU/9PIR4pHJ/S", 2, "Owla" },
                    { 3, "$2a$11$S6eqlMpjIR8Ty4/NsBpBre3UBdM3jGnvZ7thLgXAk/49LJKT/CZMK", 1, "Casha" },
                    { 4, "$2a$11$rkn2/K.VVSEcA/3O5tgaWe8gp2D0xJFBYRdfa6fPZaXEfYKO6X.tO", 2, "Tweetle" },
                    { 5, "$2a$11$YznPs0g7MbYYq0zvEflOAeIls7LaxIZ8ptLG8nwMDpNrIltXK2xlC", 1, "Grizzle" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
