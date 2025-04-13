using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Authix.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitIdentityStore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceClients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<string>(type: "TEXT", nullable: false),
                    SecretHash = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceClients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Token = table.Column<string>(type: "TEXT", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsUsed = table.Column<bool>(type: "INTEGER", nullable: false),
                    ReplacedByToken = table.Column<string>(type: "TEXT", nullable: true),
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

            migrationBuilder.InsertData(
                table: "ServiceClients",
                columns: new[] { "Id", "ClientId", "Role", "SecretHash" },
                values: new object[,]
                {
                    { 1, "unity.gateway", 0, "$2a$11$VhT1VfQFjsG4UfPQPPAjDu7xYHjX6BOyrg9L/cFByP9AlSU8fucXm" },
                    { 2, "authix.auth", 1, "$2a$11$Z.KnTJd5075lQk2DdKDbB.cPsRaSvi505WURWc5ezSvrdicairlw." },
                    { 3, "casha.cache", 2, "$2a$11$WaMKv4/fWsWqsNTu/3.jie53/byZXUEgSukK0UoBzzFeUa/jelDNO" },
                    { 4, "owla.observer", 3, "$2a$11$hPF4./QJd2.VsqJybGjLqenqUoq/G6gl9iiMDI9LrHWrTaepjtHfK" },
                    { 5, "tweetle.messenger", 4, "$2a$11$5HCAh89d5k1SmxE7ax/CNeFTSOaw9eQ8SkZy.4bFjEkiVcvGIYDv2" },
                    { 6, "squee.scheduler", 5, "$2a$11$t6gr29Wv0N/fj4t4ncZEeeOcpaFLGWMPrkU9r10rg37uokhq57N8W" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "$2a$11$EIHWWJGyhqD7GPpX8XkoNOOm/ZB7LkqHIJNbN7/x2TkVNA.3sdHS2", "Guardian", "Nymera" },
                    { 2, "$2a$11$0DglUrJi7XWB447cDHgo5eXfQK8vj.dUb6OgNRw3F.sfUiaKuE/1.", "Scout", "Erlic" },
                    { 3, "$2a$11$wlJZ18hweIKOtEmPysmJtelJHYT7Oyy0c9qDaI2I.cjQx7w0/AzPm", "Scout", "Thorne" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

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
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "ServiceClients");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
