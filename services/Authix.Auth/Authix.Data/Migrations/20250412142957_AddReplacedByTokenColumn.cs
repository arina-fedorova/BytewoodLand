using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Authix.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddReplacedByTokenColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReplacedByToken",
                table: "RefreshTokens",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$VNEkBrgMJXymYqcS65NtL.m1qR9.wz4d4Svt99fPgCumBvRlpeA2i");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$fW9uzlJELZtueHcI.x5RsuZoFHBZ2dt8SqTiHIex8.NMQYiXw.GOK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$I0Nb2ZI71zphHUoodfIoOuTUbV2iE9eVW072QRe/2R83Ieg81pSPi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$11$kbVYSybvTkntkWq1FEz2b.KAjCKPsMSwyhJuJdSANUO2Mb3K9Mfmy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$11$ZGiexl2jEVGlFU/JJ8LFiuNdCvsZlWOTi27XS4YqVx3zX6lOCIga6");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReplacedByToken",
                table: "RefreshTokens");

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
        }
    }
}
