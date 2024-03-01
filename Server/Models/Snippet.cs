using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetManager.Server.Models
{
    public class Snippet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
        public string? ApplicationUserId { get; set; }
        ApplicationUser? ApplicationUser { get; set; }
        public int? LanguageId { get; set; }
        Language? Language { get; set; }
    }
}
