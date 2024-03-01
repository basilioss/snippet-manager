using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SnippetManager.Server.Models;

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

            string userId1 = Guid.NewGuid().ToString();
            string userId2 = Guid.NewGuid().ToString();

            var user1 = new ApplicationUser
            {
                Id = userId1,
                UserName = "user@gmail.com",
                Email = "user@gmail.com",
                EmailConfirmed = true,
                NormalizedEmail = "user@gmail.com".ToUpper(),
                NormalizedUserName = "user@gmail.com".ToUpper()
            };
            var user2 = new ApplicationUser
            {
                Id = userId2,
                UserName = "user2@gmail.com",
                Email = "user2@gmail.com",
                EmailConfirmed = true,
                NormalizedEmail = "user2@gmail.com".ToUpper(),
                NormalizedUserName = "user2@gmail.com".ToUpper()
            };

            PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();
            user1.PasswordHash = hasher.HashPassword(user1, "user$Pass1");
            user2.PasswordHash = hasher.HashPassword(user2, "user$Pass2");
            modelBuilder.Entity<ApplicationUser>().HasData(user1, user2);

            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = 1, Name = "plaintext" },
                new Language() { Id = 2, Name = "clojure" },
                new Language() { Id = 3, Name = "c" },
                new Language() { Id = 4, Name = "cpp" },
                new Language() { Id = 5, Name = "csharp" },
                new Language() { Id = 6, Name = "css" },
                new Language() { Id = 7, Name = "dart" },
                new Language() { Id = 8, Name = "elixir" },
                new Language() { Id = 9, Name = "fsharp" },
                new Language() { Id = 10, Name = "go" },
                new Language() { Id = 11, Name = "html" },
                new Language() { Id = 12, Name = "java" },
                new Language() { Id = 13, Name = "javascript" },
                new Language() { Id = 14, Name = "julia" },
                new Language() { Id = 15, Name = "kotlin" },
                new Language() { Id = 16, Name = "lua" },
                new Language() { Id = 17, Name = "markdown" },
                new Language() { Id = 18, Name = "mysql" },
                new Language() { Id = 19, Name = "objective-c" },
                new Language() { Id = 20, Name = "pascal" },
                new Language() { Id = 21, Name = "perl" },
                new Language() { Id = 22, Name = "php" },
                new Language() { Id = 23, Name = "powershell" },
                new Language() { Id = 24, Name = "python" },
                new Language() { Id = 25, Name = "r" },
                new Language() { Id = 26, Name = "razor" },
                new Language() { Id = 27, Name = "redis" },
                new Language() { Id = 28, Name = "ruby" },
                new Language() { Id = 29, Name = "rust" },
                new Language() { Id = 30, Name = "scala" },
                new Language() { Id = 31, Name = "shell" },
                new Language() { Id = 32, Name = "sql" },
                new Language() { Id = 33, Name = "swift" },
                new Language() { Id = 34, Name = "typescript" },
                new Language() { Id = 35, Name = "vb" },
                new Language() { Id = 36, Name = "xml" },
                new Language() { Id = 37, Name = "yaml" },
                new Language() { Id = 38, Name = "json" }
                );

            modelBuilder.Entity<Snippet>().HasData(
                    new Snippet
                    {
                        Id = 1,
                        Title = "Hex to RGB in Python",
                        Body = "def hex_to_rgb(hex):\n" +
                            "  return tuple(int(hex[i:i+2], 16) for i in (0, 2, 4))\n\n" +
                            "hex_to_rgb('FFA501') # (255, 165, 1)",
                        ApplicationUserId = userId1,
                        LanguageId = 24
                    },
                    new Snippet
                    {
                        Id = 2,
                        Title = "String to words in Python",
                        Body = "import re\n\n" +
                            "def words(s, pattern = '[a-zA-Z-]+'):\n" +
                            "  return re.findall(pattern, s)\nn" +
                            "words('I love Python!!') # ['I', 'like', 'Python']" +
                            "words('python, javaScript & coffee') # ['python', 'javaScript', 'coffee']",
                        ApplicationUserId = userId1,
                        LanguageId = 24
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
                            "escapeHTML('<a href=\"#\">Me & you</a>');",
                        ApplicationUserId = userId2,
                        LanguageId = 13
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
                            "toSnakeCase('some text'); // 'some_text'\n",
                        ApplicationUserId = userId2,
                        LanguageId = 13
                    });

        }

        public DbSet<Snippet> Snippets { get; set; }
        public DbSet<Language> Languages { get; set; }
    }
}