using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SnippetManager.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSnippets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Snippets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snippets", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Snippets",
                columns: new[] { "Id", "Body", "Title" },
                values: new object[,]
                {
                    { 1, "def hex_to_rgb(hex):\n  return tuple(int(hex[i:i+2], 16) for i in (0, 2, 4))\n\nhex_to_rgb('FFA501') # (255, 165, 1)", "Hex to RGB in Python" },
                    { 2, "import re\n\ndef words(s, pattern = '[a-zA-Z-]+'):\n  return re.findall(pattern, s)\nnwords('I love Python!!') # ['I', 'like', 'Python']words('python, javaScript & coffee') # ['python', 'javaScript', 'coffee']", "String to words in Python" },
                    { 3, "const escapeHTML = str =>\n  str.replace(\n    /[&<>'\"]/g,\n    tag =>\n      ({\n        '&': '&amp;',\n        '<': '&lt;',\n        '>': '&gt;',\n        \"'\": '&#39;',\n        '\"': '&quot;'\n      }[tag] || tag)\n  );\n\nescapeHTML('<a href=\"#\">Me & you</a>');", "Escape HTML in JS" },
                    { 4, "const toSnakeCase = str =>\n  str &&\n  str\n    .match(/[A-Z]{2,}(?=[A-Z][a-z]+[0-9]*|)|[A-Z]?[a-z]+[0-9]*|[A-Z]|[0-9]+/g)\n    .map(x => x.toLowerCase())\n    .join('_');\n\ntoSnakeCase('camelCase'); // 'camel_case'\ntoSnakeCase('some text'); // 'some_text'\n", "Snakecase string in JS" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Snippets");
        }
    }
}
