using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SnippetManager.Server.Models;
using SnippetManager.Shared;

namespace SnippetManager.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Snippet>().HasData(
                    new Snippet
                    {
                        Id = 1,
                        Title = "Hex to RGB in Python",
                        Body = "def hex_to_rgb(hex):\n" +
                            "  return tuple(int(hex[i:i+2], 16) for i in (0, 2, 4))\n\n" +
                            "hex_to_rgb('FFA501') # (255, 165, 1)"
                    },
                    new Snippet
                    {
                        Id = 2,
                        Title = "String to words in Python",
                        Body = "import re\n\n" +
                            "def words(s, pattern = '[a-zA-Z-]+'):\n" +
                            "  return re.findall(pattern, s)\nn" +
                            "words('I love Python!!') # ['I', 'like', 'Python']" +
                            "words('python, javaScript & coffee') # ['python', 'javaScript', 'coffee']"
                    },
                    new Snippet
                    {
                        Id = 3,
                        Title = "Escape HTML in JS",
                        Body = "const escapeHTML = str =>\n" +
                            "  str.replace(\n" +
                            "    /[&<>'\"]/g,\n" +
                            "    tag =>\n" +
                            "      ({\n" +
                            "        '&': '&amp;',\n" +
                            "        '<': '&lt;',\n" +
                            "        '>': '&gt;',\n" +
                            "        \"'\": '&#39;',\n" +
                            "        '\"': '&quot;'\n" +
                            "      }[tag] || tag)\n" +
                            "  );\n\n" +
                            "escapeHTML('<a href=\"#\">Me & you</a>');"
                    },
                    new Snippet
                    {
                        Id = 4,
                        Title = "Snakecase string in JS",
                        Body = "const toSnakeCase = str =>\n" +
                            "  str &&\n" +
                            "  str\n" +
                            "    .match(/[A-Z]{2,}(?=[A-Z][a-z]+[0-9]*|\b)|[A-Z]?[a-z]+[0-9]*|[A-Z]|[0-9]+/g)\n" +
                            "    .map(x => x.toLowerCase())\n" +
                            "    .join('_');\n\n" +
                            "toSnakeCase('camelCase'); // 'camel_case'\n" +
                            "toSnakeCase('some text'); // 'some_text'\n"
                    });

        }

        public DbSet<Snippet> Snippets => Set<Snippet>();
    }
}