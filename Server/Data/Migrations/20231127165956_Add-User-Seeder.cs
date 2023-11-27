using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SnippetManager.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Snippets_AspNetUsers_ApplicationUserId",
                table: "Snippets");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Snippets",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a3bc0091-a85a-4c7f-8cfd-1a970ddc27f6", 0, "4d9e0d4c-9a23-4e63-a491-91ccc7b95250", "user2@gmail.com", true, false, null, "USER2@GMAIL.COM", "USER2@GMAIL.COM", "AQAAAAIAAYagAAAAEDfSobOdL5zmZ+mbHiRYMGOPOXTpDKnGzfuNgo/XsZA4jYNpi2bKL3NpVPyfmo0RIw==", null, false, "43f899bd-2967-4757-9f1e-40a7a04e91c9", false, "user2@gmail.com" },
                    { "e95cccfc-bba3-4c6d-a178-00126c708180", 0, "7f3f18e7-bddb-4de7-a2e3-a9f879c2e118", "user@gmail.com", true, false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAIAAYagAAAAEON9uHdH4ZX723bokDIP5JoADzWIO1uBWyJumK7FcwwJOqw/UcacHLMxFsCITWx0Hg==", null, false, "924922eb-386b-42df-874c-e198f89f24ad", false, "user@gmail.com" }
                });

            migrationBuilder.UpdateData(
                table: "Snippets",
                keyColumn: "Id",
                keyValue: 1,
                column: "ApplicationUserId",
                value: "e95cccfc-bba3-4c6d-a178-00126c708180");

            migrationBuilder.UpdateData(
                table: "Snippets",
                keyColumn: "Id",
                keyValue: 2,
                column: "ApplicationUserId",
                value: "e95cccfc-bba3-4c6d-a178-00126c708180");

            migrationBuilder.UpdateData(
                table: "Snippets",
                keyColumn: "Id",
                keyValue: 3,
                column: "ApplicationUserId",
                value: "a3bc0091-a85a-4c7f-8cfd-1a970ddc27f6");

            migrationBuilder.UpdateData(
                table: "Snippets",
                keyColumn: "Id",
                keyValue: 4,
                column: "ApplicationUserId",
                value: "a3bc0091-a85a-4c7f-8cfd-1a970ddc27f6");

            migrationBuilder.AddForeignKey(
                name: "FK_Snippets_AspNetUsers_ApplicationUserId",
                table: "Snippets",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Snippets_AspNetUsers_ApplicationUserId",
                table: "Snippets");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3bc0091-a85a-4c7f-8cfd-1a970ddc27f6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e95cccfc-bba3-4c6d-a178-00126c708180");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Snippets",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Snippets",
                keyColumn: "Id",
                keyValue: 1,
                column: "ApplicationUserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Snippets",
                keyColumn: "Id",
                keyValue: 2,
                column: "ApplicationUserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Snippets",
                keyColumn: "Id",
                keyValue: 3,
                column: "ApplicationUserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Snippets",
                keyColumn: "Id",
                keyValue: 4,
                column: "ApplicationUserId",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_Snippets_AspNetUsers_ApplicationUserId",
                table: "Snippets",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
