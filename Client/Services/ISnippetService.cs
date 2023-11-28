using SnippetManager.Shared;

namespace SnippetManager.Client.Services
{
    public interface ISnippetService
    {
        List<Snippet> Snippets { get; set; }
        Task GetSnippets();
        Task<Snippet?> GetSnippetById(int id);
        Task SearchSnippets(string searchString);
        Task CreateSnippet(Snippet snippet);
        Task UpdateSnippet(int id, Snippet snippet);
        Task DeleteSnippet(int id);
    }
}
