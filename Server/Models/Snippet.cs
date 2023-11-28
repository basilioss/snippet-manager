using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetManager.Server.Models
{
    public class Snippet
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
        public string? ApplicationUserId { get; set; }
        ApplicationUser? ApplicationUser { get; set; }
    }
}
