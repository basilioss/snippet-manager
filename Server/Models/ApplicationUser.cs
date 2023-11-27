using Microsoft.AspNetCore.Identity;

namespace SnippetManager.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Snippet> Snippets { get; set; }
    }
}