using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SnippetManager.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSnippetLanguage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Snippets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "71233d65-d88d-48d5-a6b1-08b8ebf68e6d", 0, "833d0b52-eed0-41ee-8c34-1679b6b066d5", "user@gmail.com", true, false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAIAAYagAAAAEK6Xvo0nWrrluHlmw/Yzm8rNsaWeJpAEfoi7ga9rYOMCzHYnQqLcv3cPyWVxYo3nNQ==", null, false, "6080ec79-0763-4cf3-9680-5838b4352ea9", false, "user@gmail.com" },
                    { "f358329c-050d-4a60-85f2-3123b4c88313", 0, "f5268d08-6aef-4c97-81ec-2895c539c00a", "user2@gmail.com", true, false, null, "USER2@GMAIL.COM", "USER2@GMAIL.COM", "AQAAAAIAAYagAAAAEAHFzP0NQnNOqE7QUmto7w4m6Uler0MpDVsXxI37dW7RgknSdAcxs6IEmceM03gC3A==", null, false, "ba0bcb0f-1fcc-4926-8618-2e68a94d8d94", false, "user2@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "plaintext" },
                    { 2, "clojure" },
                    { 3, "c" },
                    { 4, "cpp" },
                    { 5, "csharp" },
                    { 6, "css" },
                    { 7, "dart" },
                    { 8, "elixir" },
                    { 9, "fsharp" },
                    { 10, "go" },
                    { 11, "html" },
                    { 12, "java" },
                    { 13, "javascript" },
                    { 14, "julia" },
                    { 15, "kotlin" },
                    { 16, "lua" },
                    { 17, "markdown" },
                    { 18, "mysql" },
                    { 19, "objective-c" },
                    { 20, "pascal" },
                    { 21, "perl" },
                    { 22, "php" },
                    { 23, "powershell" },
                    { 24, "python" },
                    { 25, "r" },
                    { 26, "razor" },
                    { 27, "redis" },
                    { 28, "ruby" },
                    { 29, "rust" },
                    { 30, "scala" },
                    { 31, "shell" },
                    { 32, "sql" },
                    { 33, "swift" },
                    { 34, "typescript" },
                    { 35, "vb" },
                    { 36, "xml" },
                    { 37, "yaml" },
                    { 38, "json" }
                });

            migrationBuilder.UpdateData(
                table: "Snippets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ApplicationUserId", "LanguageId" },
                values: new object[] { "71233d65-d88d-48d5-a6b1-08b8ebf68e6d", 24 });

            migrationBuilder.UpdateData(
                table: "Snippets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ApplicationUserId", "LanguageId" },
                values: new object[] { "71233d65-d88d-48d5-a6b1-08b8ebf68e6d", 24 });

            migrationBuilder.UpdateData(
                table: "Snippets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ApplicationUserId", "LanguageId" },
                values: new object[] { "f358329c-050d-4a60-85f2-3123b4c88313", 13 });

            migrationBuilder.UpdateData(
                table: "Snippets",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ApplicationUserId", "LanguageId" },
                values: new object[] { "f358329c-050d-4a60-85f2-3123b4c88313", 13 });

            migrationBuilder.CreateIndex(
                name: "IX_Snippets_LanguageId",
                table: "Snippets",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Snippets_AspNetUsers_ApplicationUserId",
                table: "Snippets",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Snippets_Languages_LanguageId",
                table: "Snippets",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Snippets_AspNetUsers_ApplicationUserId",
                table: "Snippets");

            migrationBuilder.DropForeignKey(
                name: "FK_Snippets_Languages_LanguageId",
                table: "Snippets");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Snippets_LanguageId",
                table: "Snippets");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71233d65-d88d-48d5-a6b1-08b8ebf68e6d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f358329c-050d-4a60-85f2-3123b4c88313");

            migrationBuilder.DropColumn(
                name: "LanguageId",
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
    }
}
