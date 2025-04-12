using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Authix.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Token = table.Column<string>(type: "TEXT", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsUsed = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$GpbeYv4my6ggMt/7NUrzn..Rj8oI9Tu7kbkKgNu7HuIfuj/UFfela");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$OceXakLyDTP6Q4CoPyLO5.sYK4KQXEkpQ6nz1zhhQGb/CSZhcOz4a");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$9Z.uzQykMRtMsIxe4ti0jeMhYwPUAMlYIqFYDkijtgnPptOE8rBeG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$11$Ny4tc67XIGBT4.CAAiVXru27HyPgBBjDM0AXxb408XxiZa6o03Lsq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$11$fx2g3etcB/lrB6FGpJLVhOXW0WumAnUnazM.CWVqR/cImt0Z8u266");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$Lro27MtCVaQ4qKU72YZ7CO0gGDUoL4fpHWh46t02r1HTWrXNLWaJO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$qK1dnONJri1jf8sEt4jmF.hjEcwFb15N5Kl9bOYTVU/9PIR4pHJ/S");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$S6eqlMpjIR8Ty4/NsBpBre3UBdM3jGnvZ7thLgXAk/49LJKT/CZMK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$11$rkn2/K.VVSEcA/3O5tgaWe8gp2D0xJFBYRdfa6fPZaXEfYKO6X.tO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$11$YznPs0g7MbYYq0zvEflOAeIls7LaxIZ8ptLG8nwMDpNrIltXK2xlC");
        }
    }
}
